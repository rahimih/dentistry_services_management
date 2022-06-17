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
    
    public partial class introductionprint : Form
    {
        public Int64 introductioncode;
        public string ipadress;
        public introductionprint()
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

        private void introductionprint_Load(object sender, EventArgs e)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "dentistry";
            connectionInfo.UserID = "dentistryuser";
            connectionInfo.Password = "dentistrynothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\introductionprint_CrystalReport.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = introductioncode;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@introductioncode"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

          
            crParameterDiscreteValue.Value = introductioncode;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@introductionheadcode"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crystalReportViewer2.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            crystalReportViewer2.Refresh();  

        }
   
      

     
    }
}
