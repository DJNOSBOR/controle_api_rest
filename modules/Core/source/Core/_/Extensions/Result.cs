using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Core
{
    /// <summary>
    /// Dados de retorno
    /// </summary>
    [DataContract]
    public class Result<T>
    {
        public Result()
        {
        }

        public Result(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Dados
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// Erros
        /// </summary>
        [DataMember]
        public List<string> Errors { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        public override string ToString()
        {
            try
            {
                string errors = this.Errors != null && this.Errors.Any() ? string.Format("Errors: \"{0}\"", string.Join(", ", this.Errors)) : string.Empty;
                string data = this.Data != null ? string.Format("Data: \"{0}\"", this.Data.ToString()) : string.Empty;

                List<string> lst = new List<string>();

                if (!string.IsNullOrEmpty(errors))
                    lst.Add(errors);

                if (!string.IsNullOrEmpty(data))
                    lst.Add(data);

                return lst.Any() ? string.Join(", ", lst) : "null";
            }
            catch (Exception exception)
            {
                throw;//TODO
                //throw exception.Failin();
            }
        }

        /// <summary>
        /// Se não existir nenhum erro, retorna os dados, caso contrário, dispara uma exceção.
        /// </summary>
        public T GetValue()
        {
            return this.Errors != null
                ? throw new Exception(string.Join(",", this.Errors))
                : this.Data;
        }
    }
}