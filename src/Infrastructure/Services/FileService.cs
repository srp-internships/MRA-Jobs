﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MRA.Jobs.Application.Common.Interfaces;

namespace MRA.Jobs.Infrastructure.Services;
public class FileService : IFileService
{
    private readonly string _uploadFolderPath;
    private readonly ConcurrentDictionary<string, string> _fileMap;

    public FileService(string uploadFolderPath)
    {
        _uploadFolderPath = uploadFolderPath;
        _fileMap = new ConcurrentDictionary<string, string>();
    }

    public async Task<string> UploadAsync(IFormFile file)
    {
        var key = Guid.NewGuid().ToString();
        var filePath = Path.Combine(_uploadFolderPath, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        _fileMap[key] = file.FileName;

        return key;
    }

    public byte[] Download(string key)
    {
        if (_fileMap.TryGetValue(key, out string fileName))
        {
            var filePath = Path.Combine(_uploadFolderPath, fileName);
            return File.Exists(filePath) ? File.ReadAllBytes(filePath) : null;
        }

        return null;
    }

    public bool FileExists(string key)
    {
        return _fileMap.ContainsKey(key);
    }
}
