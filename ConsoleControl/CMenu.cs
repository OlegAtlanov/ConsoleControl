using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleControl
{
    public class CMenu : ICollection<CMenuItem>
    {
        List<CMenuItem> items = new List<CMenuItem>();
        int SelectedIndex { get; set; }

        public void Add(string itemCaption, Action callback = null)
        {
            var item = new CMenuItem(itemCaption, callback);
            items.Add(item);
        }
        public void Add(string itemCaption, CMenu innerMenu)
        {
            Action callback = () => innerMenu.Show();
            var item = new CMenuItem(itemCaption, callback);
            items.Add(item);
        }
        internal void Show()
        {
            CControl.CurrentMenu = this;
            Console.Clear();
            for (int i = 0; i < items.Count; i++)
            {
                if (i == SelectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.WriteLine(items[i].Caption);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.WriteLine(items[i].Caption);
                }
            }
        }
        internal void Up()
        {
            if (SelectedIndex > 0)
            {
                SelectedIndex--;
            }
        }
        internal void Down()
        {
            if (SelectedIndex < items.Count - 1)
            {
                SelectedIndex++;
            }
        }
        internal void Run()
        {
            if (items[SelectedIndex].CallBack != null)
            {
                items[SelectedIndex].CallBack.Invoke();
            }
        }

        public void Add(CMenuItem item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(CMenuItem item)
        {
            return items.Contains(item);
        }

        public void CopyTo(CMenuItem[] array, int arrayIndex)
        {
            items.CopyTo(array,arrayIndex);
        }

        public int Count
        {
            get { return items.Count; } 
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(CMenuItem item)
        {
            return items.Remove(item);
        }

        public IEnumerator<CMenuItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
