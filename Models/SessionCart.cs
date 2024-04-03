using DannyDefaults.Infrastructure;
using DannyDefaults.Models;
using System.Text.Json.Serialization;

namespace DannyDefaults.Models
{
    public class SessionCart : Cart
    {
        public static Cart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()
                .HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("Cart") ??
                new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession? Session { get; set; }
        public override void AddItem(Default_Model def, int quantity)
        {
            base.AddItem(def, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveLine(Default_Model def)
        {
            base.RemoveLine(def);
            Session?.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
        }
    }
}
