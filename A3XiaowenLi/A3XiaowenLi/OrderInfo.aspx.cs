using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.SqlClient;

namespace A3XiaowenLi
{
    public partial class ProductInfo : System.Web.UI.Page
    {
        string a3 = ConfigurationManager.ConnectionStrings["a3Northwind"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = "Select CategoryID, CategoryName from Categories;";

                using (SqlConnection conn = new SqlConnection(a3))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    try
                    {
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        lboxCategories.DataSource = reader;
                        lboxCategories.DataTextField = "CategoryName";
                        lboxCategories.DataValueField = "CategoryID";
                        lboxCategories.DataBind();
                    }
                    catch (SqlException sqlEX)
                    {
                        // display SQL exception
                        lblExceptions.Text = "SQL Error:" + sqlEX.ToString();
                    }
                    catch (Exception ex)
                    {
                        // display a generic exception
                        lblExceptions.Text = "Error:" + ex.ToString();
                    }
                }
                ListItem liSelect = new ListItem("Select a product", "-1");
                ddlProducts.Items.Insert(0, liSelect);
                ddlProducts.Enabled = false;
            }

        }

        protected void lboxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cid = Int32.Parse(lboxCategories.SelectedValue);
            string query = "Select ProductID, ProductName from Products where CategoryID = @Cid;";

            using (SqlConnection conn = new SqlConnection(a3))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Cid", cid);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlProducts.DataSource = reader;
                    ddlProducts.DataTextField = "ProductName";
                    ddlProducts.DataValueField = "ProductID";
                    ddlProducts.DataBind();
                }
                catch (SqlException sqlEX)
                {
                    // display SQL exception
                    lblExceptions.Text = "SQL Error:" + sqlEX.ToString();
                }
                catch (Exception ex)
                {
                    // display a generic exception
                    lblExceptions.Text = "Error:" + ex.ToString();
                }
            }

            ListItem liSelect = new ListItem("Select a product", "-1");
            ddlProducts.Items.Insert(0, liSelect);
            ddlProducts.Enabled = true;

            gvOerderDetails.DataSource = null;
            gvOerderDetails.DataBind();
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMesage.Text = "";
            if (ddlProducts.SelectedIndex > 0)
            {
                int pid = Int32.Parse(ddlProducts.SelectedValue);

                using (SqlConnection conn = new SqlConnection(a3))
                {
                    SqlCommand cmd = new SqlCommand("spOrderDetails", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pid", pid);

                    try
                    {                    
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        gvOerderDetails.DataSource = reader;
                        gvOerderDetails.DataBind();
                    }
                    catch (SqlException sqlEX)
                    {
                        // display SQL exception
                        lblExceptions.Text = "SQL Error:" + sqlEX.ToString();
                    }
                    catch (Exception ex)
                    {
                        // display a generic exception
                        lblExceptions.Text = "Error:" + ex.ToString();
                    }
                }
            }
            else
            {
                lblMesage.Text = "Please select a product";
                gvOerderDetails.DataSource = null;
                gvOerderDetails.DataBind();
            }
        }
    }
}