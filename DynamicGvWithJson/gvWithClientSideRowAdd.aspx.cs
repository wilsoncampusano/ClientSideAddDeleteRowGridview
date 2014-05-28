using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JqGrid
{
    public partial class gvWithClientSideRowAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOneRowToGrid();
            }
        }

        private void BindOneRowToGrid()
        {
            DataTable dt = defaultDataTable();
            gvDynamicRowAdd.DataSource = dt;
            gvDynamicRowAdd.DataBind();
        }

        protected void gvDynamicRowAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                lnkDelete.Attributes.Add("onclick", "return false;");
            }
        }

        protected void btn_CheckGrid_Click(object sender, EventArgs e)
        {
            DataTable dt = null;

            foreach (GridViewRow Row in gvDynamicRowAdd.Rows)
            {
                Label lblId = (Row.FindControl("lblId") as Label);
                TextBox txt_numero = Row.FindControl("txt_number") as TextBox;
                TextBox txt_ocupacion = Row.FindControl("txt_ocupacion") as TextBox;
                dt = defaultDataTable(lblId.Text, txt_numero.Text, txt_ocupacion.Text);
            }
        }


        private static DataTable defaultDataTable(params String[] values)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Numero", typeof(string));
            dt.Columns.Add("Ocupacion", typeof(string));
            DataRow dr = dt.NewRow();

            if (values.Length > 0)
            {dr["Id"] = values[0];
                dr["Numero"] = values[1];
                dr["Ocupacion"] = values[2];}
            else
            {dr["Id"] = 1;
            dr["Numero"] = "";
            dr["Ocupacion"] = "";
            }
                dt.Rows.Add(dr);

            return dt;
        }
    }
}