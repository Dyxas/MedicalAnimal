﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnimal.Controllers
{
    public interface ICard<T>
    {
        T Get(int id);
        void Delete(T card);
        void Add(T card);
        void Edit(T card);
        List<T> GetList(string filter,string order);
        ObservableCollection<T> GetObservableList(string filter, string order);
    }
}
