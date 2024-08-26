using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        private const string FilePath = "todolist.json";

        // odczytuje elementy z pliku
        public IEnumerable<ToDoItem> GetItems()
        {
            if (!File.Exists(FilePath))
            {
                return new List<ToDoItem>();
            }

            var json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<ToDoItem>>(json) ?? new List<ToDoItem>();
        }

        // dodaje nowy element do listy i zapisuje go w pliku
        public void AddItem(ToDoItem item)
        {
            var items = new List<ToDoItem>(GetItems());
            items.Add(item);
            SaveItems(items);
        }

        // usuwa element z listy i zapisuje zmiany
        public void RemoveItem(ToDoItem item)
        {
            var items = new List<ToDoItem>(GetItems());
            items.RemoveAll(i => i.Id == item.Id);
            SaveItems(items);
        }

        // zapisuje listę elementów do pliku
        private void SaveItems(IEnumerable<ToDoItem> items)
        {
            var json = JsonSerializer.Serialize(items);
            File.WriteAllText(FilePath, json);
        }
    }
}
