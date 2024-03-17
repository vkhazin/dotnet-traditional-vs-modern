# Modern vs. Traditional Performance

## Objectives

- Validate assumptions about dotnet performance using different approaches
- Implement two versions of the code: traditional and modern
- Compare performance of the two approaches: run-time and memory allocation
- Use the same IDE, input, and the same host for profiling purposes

## Method Used

- Implement two versions of the code:
  - [Traditional](Core/TraditionalDictionary.cs) 
  - and [Modern](Core/ModernDictionary.cs)
- Run a profile to compare timeline and memory allocation
- JetBrain Rider Profiler on Ubuntu 22.04 was used for testing purposes
  - 16 Cores 11th Gen Intel(R) Core(TM) i7-11850H @ 2.50GHz
  - 32GB RAM

## Findings

- Traditional & Modern timeline profiler results
![](media/timeline.png)

- Traditional memory allocation profiler results
  ![](media/memory-traditional.png)

- Modern memory allocation profiler results
  ![](media/memory-modern.png)

## Conclusions

- To my surprise it is not in favour of modern implementation
- The traditional was about 5 times faster than the modern
- The traditional consumed less than half the memory of the modern
- Have I missed something optimizing the modern approach?