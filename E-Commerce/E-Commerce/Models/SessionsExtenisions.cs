using System.Text.Json;

namespace E_Commerce.Models
{
    public static class SessionsExtenisions
    {
        public static void SetObjectToSession(this ISession session, string key, object obj)
        {
            session.SetString(key, JsonSerializer.Serialize(obj));
        }

        public static T GetObjectFromSession<T>(this ISession session, string key)
        {
            var result = session.GetString(key);

            return result == null ? default : JsonSerializer.Deserialize<T>(result);
        }
        public static int GetCartCount(this ISession session)
        {

            var Cartlst = session.GetObjectFromSession<List<CartItemViewModel>>("ShoppingCart");
            var count = Cartlst?.Sum(x => x.Quantity)?? 0;
            return count;   
        }
    }
}