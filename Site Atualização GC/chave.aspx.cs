using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class chave : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.BackColor = System.Drawing.Color.Cyan;
        TextBox1.Focus();
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string senha = "";
        senha = TextBox1.Text;


        if (senha == "#lecoteco1975")
        {

            //Response.Redirect("aTBzd2xhd3d0eGdLOTFDRWE0NEU&usp=sharing");

            //  Response.End();
            //Response.Write("<script>alert('Download de atualização não autorizado');</script>");

            Response.ContentType = "application/exe";
            Response.AddHeader("content-disposition", "attachment; filename=@\\App_LocalResources\\Chave_ADMIN.exe");
            Response.TransmitFile(@"\App_LocalResources\Chave_ADMIN.exe");
            Response.End();

        }
        if (senha == "romeu")
        {
            Response.ContentType = "application/exe";
            Response.AddHeader("content-disposition", "attachment; filename=@\\App_LocalResources\\Chave_Romeu.exe");
            Response.TransmitFile(@"\App_LocalResources\Chave_Romeu.exe");
            Response.End();
        }
        else
        {
            Response.Write("<script>alert('Senha não cadastrada');</script>");
        }               
    }
}