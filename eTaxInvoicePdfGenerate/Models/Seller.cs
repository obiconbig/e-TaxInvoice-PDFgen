namespace eTaxInvoicePdfGenerate.Models
{
    public class Seller
    {
        public string name { set; get; } = "";
        public string tax_id { set; get; } = "";
        public string phone_no { set; get; } = "";
        public string phone_ext { set; get; } = "";
        public string zipcode { set; get; } = "";
        public string address1 { set; get; } = "";
        public string address2 { set; get; } = "";
        public string email { set; get; } = "";
        public string website { set; get; } = "";
        public string fax_no { set; get; } = "";
        public string fax_ext { set; get; } = "";
        public bool is_branch { set; get; } = false;
        public string branch_id { set; get; } = "";
        public double vat { set; get; } = 0;
        public string running_prefix { set; get; } = "";
        public string running_number { set; get; } = "";
        public string province_name { set; get; } = "";
        public string province_code { set; get; } = "";
        public string district_name { set; get; } = "";
        public string district_code { set; get; } = "";
        public string subdistrict_name { set; get; } = "";
        public string subdistrict_code { set; get; } = "";
        public string house_no { set; get; } = "";
        public string inv_no { set; get; } = "";
        public string dbn_no { set; get; } = "";
        public string crn_no { set; get; } = "";

    }
}
