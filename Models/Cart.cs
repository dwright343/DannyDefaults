using Microsoft.EntityFrameworkCore.Query;

namespace DannyDefaults.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Default_Model def, int quantity)
        {
            CartLine? line = Lines
                .Where(x => x.Default_Model.DefaultId == def.DefaultId)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Default_Model = def,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Default_Model def) => Lines.RemoveAll(x => x.Default_Model.DefaultId == def.DefaultId);

        public virtual void Clear() => Lines.Clear();

        public decimal CalculateTotal()
        {
            var sum = Lines.Sum(x => 25 * x.Quantity);

            return sum;
        }
        public class CartLine
        {
            public int CartLineId { get; set; }
            public Default_Model Default_Model { get; set; }
            public int Quantity { get; set; }
        }
    }
}
