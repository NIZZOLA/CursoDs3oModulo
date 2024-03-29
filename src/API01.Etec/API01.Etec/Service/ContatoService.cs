﻿using API01.Etec.Interfaces.Repository;
using API01.Etec.Interfaces.Service;
using API01.Etec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API01.Etec.Service
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        #region Consulta
        public IEnumerable<ContatoModel> GetAll()
        {
            return _contatoRepository.GetAll().OrderBy(a => a.Nome);
        }

        public ContatoModel GetOne(int id)
        {
            return _contatoRepository.GetOne(id);
        }
        #endregion


        public ContatoModel Update(ContatoModel contato)
        {
            return _contatoRepository.Update(contato);
        }
        public ContatoModel Insert(ContatoModel contato)
        {
            if (contato.Nome == "")
                return null;

            return _contatoRepository.Insert(contato);
        }

        public bool Delete(int id)
        {
            var obj = this.GetOne(id);
            if (obj == null)
                return false;

            return _contatoRepository.Delete(obj);
        }
    }
}
