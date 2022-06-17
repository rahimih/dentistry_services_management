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
    public partial class PrintRecipe_cash_f : Form
    {
        public Int64 turnid;
        public string ipadress;
        public int feranshiz, zarib;
        public PrintRecipe_cash_f()
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

        private void PrintRecipe_f_Load(object sender, EventArgs e)
        {

            ConnectionInfo connectionInfo = new ConnectionInfo();
            TableLogOnInfos oTblLogOnInfos = new TableLogOnInfos();
            TableLogOnInfo oTblLogOnInfo = new TableLogOnInfo();
            connectionInfo.ServerName = ipadress;
            connectionInfo.DatabaseName = "dentistry";
            connectionInfo.UserID = "dentistryuser";
            connectionInfo.Password = "dentistrynothing";


            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(Application.StartupPath + @"\Recipe_cash_print.rpt");

            ParameterFieldDefinitions crParameterFieldDefinitions;
            ParameterFieldDefinition crParameterFieldDefinition;
            ParameterValues crParameterValues = new ParameterValues();
            ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();
            
            crParameterDiscreteValue.Value = turnid;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@turnid"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = turnid;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@recipeID"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = zarib;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@zarib"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

            crParameterDiscreteValue.Value = feranshiz;
            crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
            crParameterFieldDefinition = crParameterFieldDefinitions["@feranshiz"];
            crParameterValues = crParameterFieldDefinition.CurrentValues;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);


            crystalReportViewer1.ReportSource = cryRpt;
            SetLogin(connectionInfo, cryRpt);
            crystalReportViewer1.Refresh();  
        }

     
     
    }
}
