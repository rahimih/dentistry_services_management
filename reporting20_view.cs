using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;



namespace PIHO_DENTIST_SOFTWARE
{
    public partial class reporting20_view : Form
    {
        public int doctorscode_name;
        public int DoctorsCode;
        public string Turndate;
        public int turnstatus;
        public int kind;
       public string ipadress;
        public reporting20_view()
        {
            InitializeComponent();
        }
        private void SetLogin(ConnectionInfo connectionInfo, ReportDocument reportdocument)
        {
            Tables tables = reportdocument.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in tables)
            {
                TableLogOnInfo TbLogonInfo = table.LogOnInfo;
                TbLogonInfo.ConnectionInfo = connectionInfo;
                table.ApplyLogOnInfo(TbLogonInfo);
            }
        }

        private void reporting20_view_Load(object sender, EventArgs e)
        {
           
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "dentistry";
            connectionInfo.UserID = "dentistryuser";
            connectionInfo.Password = "dentistrynothing";


            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(Application.StartupPath + @"\PaientList2.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;

            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = doctorscode_name;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@doctorscode_name"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crParameterDiscreteValue.Value = DoctorsCode;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@DoctorsCode"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = Turndate;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@Turndate"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = turnstatus;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnstatus"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = kind;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@kind"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crystalReportViewer1.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            crystalReportViewer1.Refresh();  
        }

    

    

     
    }
}
