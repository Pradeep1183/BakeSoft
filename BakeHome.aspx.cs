using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace BakeSoft
{
    public partial class BakeHome : System.Web.UI.Page
    {
        DataSet dsPricingTable = null;
        ProductCode productCode = null;
        Dictionary<int, double> FirstItem = null;
        Dictionary<int, double> SecondItem = null;
        Dictionary<int, double> ThirdItem = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    dsPricingTable = new DataSet();
                    dsPricingTable = LoadPriceMatrix();

                    productCode = new ProductCode();
                    lblFirstItemName.Text = productCode.VS5 = "Vegemite Scroll";
                    lblSecondtItemName.Text = productCode.MB11 = "Blueberry Muffin";
                    lblThirdItemName.Text = productCode.CF = "Croissant";

                    LoadItemPriceMatrix(dsPricingTable);

                    double firstItemCost = ItemsCost( 10, FirstItem);
                    double secondItemCost = ItemsCost( 14, SecondItem);
                    double thirdItemCost = ItemsCost( 13, ThirdItem);

                    lblFirsttItem.Text =  firstItemCost.ToString();
                    lblSecondtItem.Text = secondItemCost.ToString();
                    lblThirdItem.Text =  thirdItemCost.ToString();

                    lblTotalAount.Text = "$  "+ CalculateTotal(firstItemCost , secondItemCost , thirdItemCost).ToString()+"  /-";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dsPricingTable.Dispose();
                productCode = null;
                FirstItem = SecondItem = ThirdItem = null;
            }        
        }

        /// <summary>
        /// Determine the minimum item cost as per quantity
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="quantity"></param>
        /// <param name="Pieces"></param>
        /// <returns></returns>
        public double ItemsCost(int quantity,Dictionary<int, double> Pieces)
        {
            double itemPrice = 0.00;

            Pieces = Pieces.OrderByDescending(u => u.Value).ToDictionary(z => z.Key, y => y.Value);

            for (int i = 0; i < Pieces.Count; i++)
            {
                itemPrice = 0.00;

                int quo = quantity / Pieces.ElementAt(i).Key;

                itemPrice += Pieces.ElementAt(i).Value * quo;

                var rem = (quantity % Pieces.ElementAt(i).Key);

                if (rem != 0 && Pieces.Count > (i + 1) && (rem % Pieces.ElementAt(i + 1).Key) == 0)
                {
                    itemPrice += rem / Pieces.ElementAt(i + 1).Key * Pieces.ElementAt(i + 1).Value;
                    return itemPrice;
                }
                else
                {
                    if (rem != 0 && Pieces.Count > (i + 2) && (rem % Pieces.ElementAt(i + 2).Key) == 0)
                    {
                        itemPrice += rem / Pieces.ElementAt(i + 2).Key * Pieces.ElementAt(i + 2).Value;
                        return itemPrice;
                    }
                    else
                    {
                        if (rem != 0)
                        {
                            itemPrice = 0;
                        }
                    }
                }
                if (rem == 0)
                {
                    return itemPrice;
                }
            }
            return itemPrice;
        }


        /// <summary>
        /// Loading the price matrix as per product code
        /// </summary>
        /// <param name="ds"></param>
        public void LoadItemPriceMatrix(DataSet ds)
        {
            FirstItem = new Dictionary<int, double>();
            SecondItem = new Dictionary<int, double>();
            ThirdItem = new Dictionary<int, double>();
            int key = 0; double value = 0.00;

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["ProductCode"].ToString() == "VS5")
                {
                    key = int.Parse( ds.Tables[0].Rows[i]["Quantity"].ToString());
                    value = double.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                    FirstItem.Add(key,value);
                }
                else if (ds.Tables[0].Rows[i]["ProductCode"].ToString() == "MB11")
                {
                    key = int.Parse(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    value = double.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                    SecondItem.Add(key, value);
                }
                else if (ds.Tables[0].Rows[i]["ProductCode"].ToString() == "CF")
                {
                    key = int.Parse(ds.Tables[0].Rows[i]["Quantity"].ToString());
                    value = double.Parse(ds.Tables[0].Rows[i]["price"].ToString());
                    ThirdItem.Add(key, value);
                }
            }
            
        }


        /// <summary>
        /// Load the base pricing matrix from configured XML file
        /// </summary>
        /// <returns></returns>
        public DataSet LoadPriceMatrix()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory+"ProductPricing.xml");
            return ds;
        }

        /// <summary>
        /// Calculation for the billing
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public double CalculateTotal(double x, double y,double z)
        {
            return x + y + z;
        }        
    }    
    
    //Creating product code
    public class ProductCode
    {       
        public string VS5 { get; set; }
        public string MB11 { get; set; }
        public string CF { get; set; }
    }        
}
