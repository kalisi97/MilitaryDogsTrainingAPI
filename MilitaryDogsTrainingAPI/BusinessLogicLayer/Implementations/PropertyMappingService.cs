using MilitaryDogsTrainingAPI.BusinessLogicLayer.Interfaces;
using MilitaryDogsTrainingAPI.Entities;
using MilitaryDogsTrainingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilitaryDogsTrainingAPI.BusinessLogicLayer.Implementations
{
    public class PropertyMappingService:IPropertyMappingService
    {
        private Dictionary<string, PropertyMappingValue> _propertyMapping =
          new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
          {
              //dodati jos propertija za sortiranje ako je potrebno
                  { "Name", new PropertyMappingValue(new List<string>() { "Name" } ) },
               { "Gender", new PropertyMappingValue(new List<string>() { "Gender" } )},
                 { "Breed", new PropertyMappingValue(new List<string>() { "Breed" } )},
               { "Age", new PropertyMappingValue(new List<string>() { "DateOfBirth" } , true) },
              
          };

        private IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<DogDTO, Dog>(_propertyMapping));
        }

        public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
        {
            var propertyMapping = GetPropertyMapping<TSource, TDestination>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                return true;
            }

            // string je podeljen po "," pa ga splitujemo
            var fieldsAfterSplit = fields.Split(',');

            // prolazimo kroz polja splitovanog stringa 
            foreach (var field in fieldsAfterSplit)
            {
                // trim
                var trimmedField = field.Trim();

            
                // ignored sve nakon prvog " " space-a kada polje dolazi od 
                //order by stringa mora biti ignosrisano
                var indexOfFirstSpace = trimmedField.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ?
                    trimmedField : trimmedField.Remove(indexOfFirstSpace);

                // trazi matching property
                if (!propertyMapping.ContainsKey(propertyName))
                {
                    return false;
                }
            }
            return true;
        }


        public Dictionary<string, PropertyMappingValue> GetPropertyMapping
           <TSource, TDestination>()
        {
            // uzima matching property
            var matchingMapping = _propertyMappings
                .OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First()._mappingDictionary;
            }

            throw new Exception($"Cannot find exact property mapping instance " +
                $"for <{typeof(TSource)},{typeof(TDestination)}");
        }
    }
}
