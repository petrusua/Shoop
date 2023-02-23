using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
namespace wwrk.Domain.Entities;


public class TShirtDatabase
{
	private readonly string _filePath;
	private List<TShirt> _tShirts;
	public TShirtDatabase(string filePath)
	{
		_filePath = filePath;
		Load();
	}

	public IReadOnlyList<TShirt> GetAll()
	{
        return _tShirts;
	}

	public void Add(TShirt tShirt)
	{
		_tShirts.Add(tShirt);
		Save();
	}

	public void Update(TShirt tShirt)
	{
		var index = _tShirts.FindIndex(p => p.Name == tShirt.Name);
		if (index != -1)
		{
			_tShirts[index] = tShirt;
			Save();
		}
	}

	public void Delete(string name)
	{
		var index = _tShirts.FindIndex(p => p.Name == name);
		if (index != -1)
		{
			_tShirts.RemoveAt(index);
			Save();
		}
	}

	private void Load()
	{
		if (File.Exists(_filePath))
		{
			var json = File.ReadAllText(_filePath);
			_tShirts = JsonConvert.DeserializeObject<List<TShirt>>(json);
		}
		else
		{
			_tShirts = new List<TShirt>();
		}
	}

	private void Save()
	{
		var json = JsonConvert.SerializeObject(_tShirts, Formatting.Indented);
		File.WriteAllText(_filePath, json);
	}
}
