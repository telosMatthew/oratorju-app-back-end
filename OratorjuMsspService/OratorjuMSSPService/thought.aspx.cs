using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OratorjuMSSPService
{
    public partial class thought : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddThought_click(object sender, EventArgs e)
        {
            try {
                DateTime t_date = DateTime.ParseExact(txtthoughtDate.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                if (UtilsThought.addThought(t_date, txtFriendlyDate.Text, Request.Form["txtContent"], UploadFile()))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "correct_input", "alert('Kollox sew :) - Hsieb miżjud!')", true);
                    Response.Redirect("./index.aspx");
                }
                else //Thought not added
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
            if (UtilsThought.deleteThought(GridView1.DataKeys[e.RowIndex].Value.ToString()))
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
           // GridView1.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gvbind();
        }
        protected void gridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)GridView1.Rows[e.RowIndex];
                if (UtilsThought.updateThought(
                        (row.Cells[0].Text), 
                        ((TextBox)row.Cells[1].Controls[0]).Text,
                        ((TextBox)row.Cells[2].Controls[0]).Text,
                        null))
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
            UtilsThought.getAllThoughts();
        }

        private string UploadFile()
        {
            string fileName = Path.GetFileName(fuImage.PostedFile.FileName);
            fuImage.PostedFile.SaveAs(Server.MapPath("~/Uploads/") + fileName);
        
            return "./Uploads/" + fileName;
        }

        protected void DownloadFile(object sender, EventArgs e)
        {
            string filePath = (sender as LinkButton).CommandArgument;
            Response.ContentType = ContentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
            Response.WriteFile(filePath);
            Response.End();
        }

    }
}