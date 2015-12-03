using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OratorjuMSSPService
{
    public partial class reading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddReading_click(object sender, EventArgs e)
        {
            try {
                DateTime r_date = DateTime.ParseExact(txtReadingDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


                if (Utils.addReading(r_date, Request.Form["txtQari1"], Request.Form["txtSalm"], Request.Form["txtQari2"], Request.Form["txtVangelu"],txtFriendlyDate.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "correct_input", "alert('Kollox sew :) - Qari miżjud!')", true);
                    Response.Redirect("./index.aspx");
                }
                else //reading not added
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "incorrect_input", "alert('Daħħalt informazzjoni ħażina xbin!')", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "incorrect_input", "alert('Daħħalt informazzjoni ħażina xbin!')", true);

            }

        }

        protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Utils.deleteReading(GridView1.DataKeys[e.RowIndex].Value.ToString()))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "delete_ok", "alert('Ir-ringiela ġiet imħassra!')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "delete_notOk", "alert('Ir-ringiela ma ġietx imħassra!')", true);
            }
            gvbind();

        }
        protected void gridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            gvbind();
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                if (Utils.updateReading(
                        (row.Cells[0].Text), 
                        ((TextBox)row.Cells[1].Controls[0]).Text,
                        ((TextBox)row.Cells[2].Controls[0]).Text,
                        ((TextBox)row.Cells[3].Controls[0]).Text,
                        ((TextBox)row.Cells[4].Controls[0]).Text,
                        ((TextBox)row.Cells[5].Controls[0]).Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "update_ok", "alert('Ir-ringiela ġiet aġġornata!')", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "update_notOk", "alert('Ir-ringiela ma ġietx aġġornata!')", true);
                }

                gvbind();
            }
            catch (Exception ex)
            {

            }
        }

        protected void gridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            gvbind();
        }

        protected void gvbind()
        {
            Utils.getAllReadings();
        }

    }
}