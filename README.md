# vertices-puzzle
Cherwell Software Technical Interview puzzle - C# Web API Endpoint  
My implemented code is located at TrianglePuzzle/Controllers/  

Runs on localhost  
Responds to JSON POST requests of the form:  

{  
    "type":"A",  
    "rowLetter":"x",  
    "columnNo":"y"  
}  
(Task A) 


Where x: upper or lowercase letter (A-F)  
      y: number from 1-12  


or  

{  
    "type":"B":,  
    "v1x":"x1",  
    "v1y":"y1",  
    "v2x":"x2",  
    "v2y":"y2",  
    "v3x":"x3",  
    "v3y":"y3"  
}  

(Task B)

Where (x1, y1), (x2, y2), (x3, y3) are the coordinates of the vertices of the desired triangle.



