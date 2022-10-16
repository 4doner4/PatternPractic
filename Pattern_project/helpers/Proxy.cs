namespace Pattern_project.helpers
{
    public interface ISubject
    {
        string[] Request(int n);
    }

    class RealSubject : ISubject
    {
        public string[] items1 = new string[] { "Аметов Дамир", "Еволенко Алексей", "Мендешев Темирлан" };
        public string[] items2 = new string[] { "Атбаш", "Цезарь", "XOR", "ADFGX", "Вижинер" };
        public string[] Request(int n)
        {
            if (n == 1)
            {
                return items1;
            }
            else
            {
                return items2;
            }
        }
    }

    class Proxy : ISubject
    {
        private RealSubject _realSubject;

        public Proxy(RealSubject realSubject)
        {
            this._realSubject = realSubject;
        }

        public string[] Request(int n)
        {
            if (this.CheckAccess()) {
                return this._realSubject.Request(n);
            }
            else {
                return null!;
            };
        }

        public bool CheckAccess()
        {
            bool cheker = true;
            foreach(string i in _realSubject.items1)
            {
                if (i.GetType() == typeof(string))
                {
                    cheker = true;
                }
                else
                {
                    cheker = false;
                    break;
                }
            }
            return cheker;
           
        }

    }
    public class Client
    {
        public string[] ClientCode(ISubject subject, int n)
        {

            return subject.Request(n);

        }


    }
}
