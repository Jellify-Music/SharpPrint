# SharpPoint

C# Bindings for some of essentia main features. 

# Building

LOL, good luck 👏

# Using 
```csharp
 const float sampleRate = 44100;
        
 Essentia.init();
 AlgorithmFactory factory = new AlgorithmFactory();
 MonoLoader loader = new MonoLoader(factory, "/whatever track.mp3", sampleRate);
 ChromaPrinter chroma = new ChromaPrinter(factory, 3, sampleRate);

 string signature = chroma.Scan(loader);
        
 Console.WriteLine("Generated signature for song: " + signature);
 Essentia.destroy();
```

Created by [Brys0](https://github.com/brys0) in collaboration with [Jellify](https://github.com/Jellify-Music)