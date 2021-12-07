using AppInmobiliaria.Entidades;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Text;

namespace AppInmobiliaria
{
    //Se encarga de emItir los metodos CRUD
    public class ClassMiRepositorio<T> where T:ClassBaseDTO
    {

        MongoClient client;
        IMongoDatabase db;
        bool resultado;
        //Es privado porque el error lo voy obtener de las operaciones de la base de datos
        public string Error { get;private set; }
        //Doble tabulador t crea el objeto constructor
        public ClassMiRepositorio()
        {
            client = new MongoClient("mongodb+srv://user-pruebabase:donpepe2021@cluster0.uc7r1.mongodb.net/myFirstDatabase?retryWrites=true&w=majority");
            db = client.GetDatabase("Cluster0");
        }
        private IMongoCollection<T> Collection()=>db.GetCollection<T>(typeof(T).Name);

        public T Create(T entidad)
        {
            entidad.id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            entidad.FechaHora = DateTime.Now;
            try
            {
                Collection().InsertOne(entidad);
                Error = "";
                resultado = true;
            }
            catch (Exception ex )
            {

                Error = ex.Message;
                resultado = false;
            }
            return resultado ? entidad : null;
        }
        public IEnumerable<T> Read { 
                     get

                        //Regresa mi colleccion
                     {
                        try
                        {
                            Error = "";
                            return Collection().AsQueryable();   

                        }
                        catch (Exception ex)
                        {
                            Error = ex.Message;
                            return null;    
                        
                        }
                     } 
                
                }
            public T Update(T entidad)
            {
                entidad.FechaHora = DateTime.Now;
                try
                {

                    int r = (int)Collection().ReplaceOne(e => e.id ==entidad.id,entidad).ModifiedCount;
                    Error = r == 1 ? "Elemento Modificado":"No se modifico el elemento";
                    resultado = r == 1;
                }
                catch (Exception ex)
                {

                    Error = ex.Message;
                    resultado = false;
                }
                    return resultado ? entidad : null;
     
             }

           public bool Delete(T entidad)
           {

                try
                {
                int r = (int)Collection().DeleteOne(e => e.id == entidad.id).DeletedCount;
                    resultado = r == 1;
                    Error = resultado ? "Elemento Eliminado" : "No se pudo eliminar el elemento";
                }
                catch (Exception ex)
                {
                    Error = ex.Message;
                    resultado = false;
                }
                
                return resultado;
                
           }
        public T SearchById(String id)
        {
            return Collection().Find(e => e.id == id).SingleOrDefault();

        }
        public IEnumerable<T> Query(Expression<Func<T,bool>> predicado)
        {
            return Read.Where(predicado.Compile());
        }
    }       
    


}
