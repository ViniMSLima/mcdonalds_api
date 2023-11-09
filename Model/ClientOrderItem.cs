using System;
using System.Collections.Generic;

namespace mcdonalds_api.Model;

public partial class ClientOrderItem
{
    public int Id { get; set; }

    public int ClientOrderId { get; set; }

    public int ProductId { get; set; }

    public virtual ClientOrder ClientOrder { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
