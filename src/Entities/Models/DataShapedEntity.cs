﻿
#region (c) 2022 Binary Builders Inc. All rights reserved.

//-----------------------------------------------------------------------
// <copyright> 
//       File: D:\Dev\Src\GitHub\PointOfSale\PosApi\src\Entities\Models\Entity.cs
//     Author:  
//     Copyright (c) 2022 Binary Builders Inc.. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//-----------------------------------------------------------------------

#endregion

using Entities.LinkModels;
using System.Collections;
using System.Dynamic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Entities.Models;

public class DataShapedEntity : DynamicObject, IXmlSerializable, IDictionary<string, object>
{
    private readonly string _root = "Entity";
    private readonly IDictionary<string, object> _expando;

    public DataShapedEntity()
    {
        _expando = new ExpandoObject();
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        if (_expando.TryGetValue(binder.Name, out object value))
        {
            result = value;
            return true;
        }

        return base.TryGetMember(binder, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        _expando[binder.Name] = value;

        return true;
    }

    public XmlSchema GetSchema()
    {
        throw new NotImplementedException();
    }

    public void ReadXml(XmlReader reader)
    {
        reader.ReadStartElement(_root);

        while (!reader.Name.Equals(_root))
        {
            string typeContent;
            Type underlyingType;
            var name = reader.Name;

            reader.MoveToAttribute("type");
            typeContent = reader.ReadContentAsString();
            underlyingType = Type.GetType(typeContent);
            reader.MoveToContent();
            _expando[name] = reader.ReadElementContentAs(underlyingType, null);
        }
    }

    public void WriteXml(XmlWriter writer)
    {
        foreach (var key in _expando.Keys)
        {
            var value = _expando[key];
            WriteLinksToXml(key, value, writer);
        }
    }

    private void WriteLinksToXml(string key, object value, XmlWriter writer)
	{
		writer.WriteStartElement(key);

		if (value.GetType() == typeof(List<Link>))
		{
			foreach (var val in value as List<Link>)
			{
				writer.WriteStartElement(nameof(Link));
				WriteLinksToXml(nameof(val.Href), val.Href, writer);
				WriteLinksToXml(nameof(val.Method), val.Method, writer);
				WriteLinksToXml(nameof(val.Rel), val.Rel, writer);
				writer.WriteEndElement();
			}
		}
		else
		{
			writer.WriteString(value.ToString());
		}

		writer.WriteEndElement();
	}

    public void Add(string key, object value)
    {
        _expando.Add(key, value);
    }

    public bool ContainsKey(string key)
    {
        return _expando.ContainsKey(key);
    }

    public ICollection<string> Keys
    {
        get { return _expando.Keys; }
    }

    public bool Remove(string key)
    {
        return _expando.Remove(key);
    }

    public bool TryGetValue(string key, out object value)
    {
        return _expando.TryGetValue(key, out value);
    }

    public ICollection<object> Values
    {
        get { return _expando.Values; }
    }

    public object this[string key]
    {
        get
        {
            return _expando[key];
        }
        set
        {
            _expando[key] = value;
        }
    }

    public void Add(KeyValuePair<string, object> item)
    {
        _expando.Add(item);
    }

    public void Clear()
    {
        _expando.Clear();
    }

    public bool Contains(KeyValuePair<string, object> item)
    {
        return _expando.Contains(item);
    }

    public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
    {
        _expando.CopyTo(array, arrayIndex);
    }

    public int Count
    {
        get { return _expando.Count; }
    }

    public bool IsReadOnly
    {
        get { return _expando.IsReadOnly; }
    }

    public bool Remove(KeyValuePair<string, object> item)
    {
        return _expando.Remove(item);
    }

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
        return _expando.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
