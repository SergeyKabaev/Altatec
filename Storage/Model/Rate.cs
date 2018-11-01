using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Common.Model
{
    [DataContract]
    [Table("Rate")]
    public class Rate
    {
        [DataMember]
        public string RateName { get; set; }
        [DataMember]
        public DateTime Dt { get; set; }
        [DataMember]
        public decimal BuyValue { get; set; }
        [DataMember]
        public decimal SellValue { get; set; }
    }
}
