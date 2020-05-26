namespace webApi.Models
{
    public class Hello
    {
        public string hello { get; set; } = "За допомогою цієї Апі" +
            " ви можете отримати інформацію по MAC-адресу, IP-адресу та Gmail-пошті у вигляді Json файлу.";
    }
    public class Bad
    {
        public string bad { get; set; } = "Щось пішло не так, перевірте вхідні дані";

    }
}
