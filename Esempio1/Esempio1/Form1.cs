using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Esempio1
{
    public partial class Form1 : Form
    {

        private int Conteggio = 0;
        public Form1()
        {
            InitializeComponent();
            lblConta.Text = this.Conteggio.ToString();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            lblWait.Text = "Sto elaborando...";
            // Task.Run(() => Task.Delay(3000));
            // var u = Task.Run(() => OttieniUtenti()).Result;
            await Task.Delay(3000);
            lblWait.Text = "OK";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Conteggio++;
            lblConta.Text = this.Conteggio.ToString();
        }

        private async void BtnLoad_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = await OttieniUtenti();
        }

        private async Task<List<utenti>> OttieniUtenti()
        {
            var utenti = new List<utenti>();
            utenti.Add(new Esempio1.utenti { nome = "Andrea", cognome = "Colleoni", indirizzo = "Stezzano" });

            MegaDb db = new MegaDb();
            // db.Database.SqlQuery<utenti>("select * from utenti", null);
            foreach (var u in await db.utenti.Where(x => x.indirizzo != "Scanzo").ToListAsync())
            {
                utenti.Add(u);
            }
            ListaUtenti l = new ListaUtenti();
            XmlSerializer ser = new XmlSerializer(l.GetType());
            TextReader reader = new StreamReader(@"c:\logs\utenti-new.xml");
            ListaUtenti utentiXml = await Task.FromResult((ListaUtenti)ser.Deserialize(reader));
            foreach (var u in utentiXml.ElencoUtenti)
            {
                utenti.Add(u);
            }

            /*
            l.ElencoUtenti = utenti;
            XmlElement element = new XmlDocument().CreateElement("Utenti", "mega");
            TextWriter writer = new StreamWriter(@"c:\logs\utenti.xml");
            ser.Serialize(writer, l);
            writer.Close();
            */
            return utenti;
        }
    }
}
