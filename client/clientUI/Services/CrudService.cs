﻿using clientUI.Model;
using clientUI.ServerApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clientUI.Services
{
    public class CrudService<ID, TYPE, DTO> where TYPE : DomainEntity<ID>
    {
        protected readonly CrudRequester<ID, TYPE, DTO> requester;

        public TYPE Read(ID id)
        {
            if (id is null)
            {
                throw new ArgumentNullException("id");
            }
            try
            {
                return requester.Get(id);
            }
            catch(Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }

        public List<TYPE> ReadAll()
        {
            try
            {
                return requester.GetAll();
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }

        public virtual TYPE Create(TYPE entity)
        {
            try
            {
                return requester.Post(entity);
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }

        public virtual void Update(TYPE entity)
        {
            try
            {
                requester.Put(entity, entity.getId());
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }

        public void Delete(TYPE entity)
        {
            try
            {
                requester.Delete(entity.getId());
            }
            catch (Exception ex)
            {
                if (ex is TaskCanceledException || ex is HttpRequestException)
                {
                    throw new Exception("Connection to server failed. Please check internet connection.");
                }
                throw;
            }
        }
    }
}
