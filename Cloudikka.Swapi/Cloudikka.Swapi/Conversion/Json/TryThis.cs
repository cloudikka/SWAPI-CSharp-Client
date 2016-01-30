﻿using Newtonsoft.Json;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloudikka.Swapi.Conversion.Json {
    public class TryThisConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            var typeDefinition = typeof(SwapiReference<>);
            if(objectType.GetGenericTypeDefinition() == typeDefinition) {
                return true;
            }

            return false;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            Uri uri;

            if(reader.Value is string && Uri.TryCreate(reader.Value as string, UriKind.RelativeOrAbsolute, out uri)) {
                var result = Activator.CreateInstance(objectType) as SwapiObject;
                result.Url = uri;

                return result;
            }

            return existingValue;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            
        }
    }
}
