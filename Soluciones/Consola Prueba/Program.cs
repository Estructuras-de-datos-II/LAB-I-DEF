using System;



namespace Consola_Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var arbol = new BTree<int>(5);
            
            arbol.insertar(10);
            arbol.insertar(54);
            arbol.insertar(25);
            arbol.insertar(81);
            arbol.insertar(86);
            arbol.insertar(87);
            arbol.insertar(9);
            arbol.insertar(74);
            arbol.insertar(51);
            arbol.insertar(47);
            arbol.insertar(46);
            arbol.insertar(12);
            arbol.insertar(16);
            arbol.insertar(34);
            arbol.insertar(36);
            arbol.insertar(96);
            arbol.insertar(44);
            arbol.insertar(6);
            arbol.insertar(19);
            arbol.insertar(64);
            arbol.insertar(21);
            arbol.insertar(60);
            arbol.insertar(50);
            arbol.insertar(90);


            arbol.eliminar(51);
            arbol.eliminar(34);
            arbol.eliminar(10);
            arbol.eliminar(12);
            arbol.eliminar(81);
            arbol.eliminar(60);
            arbol.eliminar(90);
            arbol.eliminar(46);


            bool si = arbol.existeValor(21);
            bool no = arbol.existeValor(100);


        }
    }
}
