using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections;

namespace Firestorm.Infra.Utils
{
    public static class ViewModelUtils
    {
        public static TViewModel ToViewModel<TModel, TViewModel>(TModel model) 
        {
            return Mapper.Map<TModel, TViewModel>(model);
        }

        public static IEnumerable<TViewModel> ToListViewModel<TModel,TViewModel>(IEnumerable<TModel> model)
        {
            foreach (var item in model)
                yield return Mapper.Map<TModel, TViewModel>(item);
        }

        public static IEnumerable ToListViewModel<TModel>(IEnumerable<TModel> source)
        {
            Type destinationType = (from x in Mapper.GetAllTypeMaps()
                                    where x.SourceType == typeof(TModel)
                                    select x.DestinationType).FirstOrDefault();

            foreach (var item in source)
            {
                if (destinationType != null)
                {
                     yield return Mapper.Map(item, typeof(TModel), destinationType);
                }
            }
            
        }

        public static IEnumerable ToListViewModel<TModel>(IQueryable source)
        {
            Type destinationType = (from x in Mapper.GetAllTypeMaps()
                                    where x.SourceType == typeof(TModel)
                                    select x.DestinationType).FirstOrDefault();

            foreach (var item in source)
            {
                if (destinationType != null)
                {
                    if (item.GetType().IsGenericType)
                    {
                        var genericType = item.GetType().GetGenericArguments().FirstOrDefault();

                        if (genericType == typeof(TModel))
                        {
                            foreach (var genericItem in item as IList<TModel>)
                            {
                                yield return Mapper.Map(genericItem, typeof(TModel), destinationType);
                            }

                        }
                    }
                    else
                    {
                        yield return Mapper.Map(item, typeof(TModel), destinationType);
                    }
                }
            }

        }


        public static TModel ToModel<TViewModel, TModel>(TViewModel viewModel)
        {
            return Mapper.Map<TViewModel, TModel>(viewModel);
        }
    }
}
