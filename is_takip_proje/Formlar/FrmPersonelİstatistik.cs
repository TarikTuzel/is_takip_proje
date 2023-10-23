using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using is_takip_proje.Entity;

namespace is_takip_proje.Formlar
{
    public partial class FrmPersonelİstatistik : Form
    {
        public FrmPersonelİstatistik()
        {
            InitializeComponent();
        }

        DbisTakipEntities db = new DbisTakipEntities();
        private void FrmPersonelİstatistik_Load(object sender, EventArgs e)
        {
            LblToplamDepartman.Text= db.TblDepartmanlar.Count().ToString();
            LblToplamFirma.Text=db.TblFirmalar.Count().ToString();
            LblToplamPersonel.Text=db.TblPersonel.Count().ToString();
            LblAktifIs.Text=db.TblGorevler.Count(x=>x.Durum=="1").ToString();
            LblPasifIs.Text=db.TblGorevler.Count(x=>x.Durum=="0").ToString();
            LblSonGorev.Text=db.TblGorevler.OrderByDescending(x=>x.ID).Select(x=>x.Aciklama).FirstOrDefault();
            LblSehir.Text=db.TblFirmalar.Select(x=>x.il).Distinct().Count().ToString();
            LblSektor.Text=db.TblFirmalar.Select(x=>x.Sektor).Distinct().Count().ToString();

        }
    }
}
