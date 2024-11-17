using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjList = new Dictionary<int, List<int>>();

    public void AddEdge(int v, int w)
    {
        if (!adjList.ContainsKey(v))
        {
            adjList[v] = new List<int>();
        }
        
        if (!adjList.ContainsKey(w))
        {
            adjList[w] = new List<int>();
        }

        adjList[v].Add(w);
        adjList[w].Add(v);
    }

    public void DFS(int v, HashSet<int> visited, List<int> component)
    {
        visited.Add(v);
        component.Add(v);
        if (adjList.ContainsKey(v))
        {
            foreach (int item in adjList[v])
            {
                if (!visited.Contains(item))
                {
                    DFS(item, visited, component);
                }
            }
        }
    }

    public List<List<int>> FindConnectedComponents()
    {
        HashSet<int> visited = new HashSet<int>();
        List<List<int>> components = new List<List<int>>();

        foreach (var vertex in adjList.Keys)
        {
            if (!visited.Contains(vertex))
            {
                List<int> component = new List<int>();
                DFS(vertex, visited, component);
                components.Add(component);
            }
        }

        return components;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Пример:");
        Graph graph = new Graph();

        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(3, 4);
        graph.AddEdge(5, 6);
        graph.AddEdge(6, 7);

        List<List<int>> components = graph.FindConnectedComponents();

        Console.WriteLine("Компоненты связности:");
        foreach (var component in components)
        {
            Console.WriteLine("{" + string.Join(", ", component) + "}");
        }

        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Тесты");
        Console.WriteLine(" ");

        Graph emptyGraph = new Graph();
        List<List<int>> emptyComponents = emptyGraph.FindConnectedComponents();
        Console.WriteLine("Компоненты связности:");
        foreach (var component in emptyComponents)
        {
            Console.WriteLine("{" + string.Join(", ", component) + "}");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Если сообщение пустое, то всё правильно, это пустой граф");

        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(" ");

        Graph singleVertexGraph = new Graph();
        singleVertexGraph.AddEdge(0, 0);
        List<List<int>> singleVertexComponents = singleVertexGraph.FindConnectedComponents();
        Console.WriteLine("Компоненты связности:");
        foreach (var component in singleVertexComponents)
        {
            Console.WriteLine("{" + string.Join(", ", component) + "}");
        }      
        Console.WriteLine(" ");
        Console.WriteLine("Если в сообщении одно значение, то всё правильно, это граф с одной вершиной");  

        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(" ");
        

        Graph singleComponentGraph = new Graph();
        singleComponentGraph.AddEdge(0, 1);
        singleComponentGraph.AddEdge(1, 2);
        singleComponentGraph.AddEdge(2, 3);
        List<List<int>> singleComponent = singleComponentGraph.FindConnectedComponents();
        Console.WriteLine("Компоненты связности:");
        foreach (var component in singleComponent)
        {
            Console.WriteLine("{" + string.Join(", ", component) + "}");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Если в сообщении одно множество значений, то всё правильно, это граф с одной компонентой связности");  

        Console.WriteLine(" ");
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine(" ");

        Graph multipleComponentsGraph = new Graph();
        multipleComponentsGraph.AddEdge(0, 1);
        multipleComponentsGraph.AddEdge(2, 3);
        multipleComponentsGraph.AddEdge(4, 5);
        List<List<int>> multipleComponents = multipleComponentsGraph.FindConnectedComponents();
        Console.WriteLine("Компоненты связности:");
        foreach (var component in multipleComponents)
        {
            Console.WriteLine("{" + string.Join(", ", component) + "}");
        }
        Console.WriteLine(" ");
        Console.WriteLine("Если в сообщении несколько множеств значений, то всё правильно, это граф с несколькими компонентами связности");  
    }
}
