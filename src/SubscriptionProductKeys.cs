using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false, ElementName = "root")]
public partial class SubscritionProductKeys
{
    [XmlElement("YourKey", typeof(ProductKeys), Form = XmlSchemaForm.Unqualified)]
    [XmlElement("YourSubscription", typeof(Subscription), Form = XmlSchemaForm.Unqualified)]
    public object[]? Items { get; set; }

    public Subscription? Subscriptions => Items?.FirstOrDefault(i => i is Subscription) as Subscription;

    public ProductKeys? ProductKeys => Items?.FirstOrDefault(i => i is ProductKeys) as ProductKeys;
}

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class ProductKeys
{
    [XmlElement("Product_Key", Form = XmlSchemaForm.Unqualified)]
    public Product[]? Products { get; set; }
}

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class Product
{
    [XmlElement("Key", Form = XmlSchemaForm.Unqualified, IsNullable = true)]
    public ProductKey[]? Keys { get; set; }

    [XmlAttribute]
    public string? Name { get; set; }

    [XmlAttribute]
    public string? KeyRetrievalNote { get; set; }
}

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class ProductKey
{
    [XmlAttribute(AttributeName = "ID")]
    public string? IdField { get; set; }

    public int ID => int.Parse(IdField ?? "-1");

    [XmlAttribute]
    public string? Type { get; set; }

    [XmlAttribute]
    public string? ClaimedDate { get; set; }

    [XmlAttribute(AttributeName = "notes")]
    public string? Notes { get; set; }

    [XmlText]
    public string? Value { get; set; }
}

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class Subscription
{
    [XmlElement("Subscription", Form = XmlSchemaForm.Unqualified)]
    public SubscriptionDetails[]? Subscriptions { get; set; }
}

[Serializable, DebuggerStepThrough, DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public partial class SubscriptionDetails
{
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string? SubscriptionGuid { get; set; }

    [XmlAttribute]
    public string? Name { get; set; }

    [XmlAttribute]
    public string? Type { get; set; }
}
