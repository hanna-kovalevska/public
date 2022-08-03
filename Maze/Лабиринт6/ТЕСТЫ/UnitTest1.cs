using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using Лабиринт6;

namespace ТЕСТЫ
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            bool answer = true;
            bool tru_answer = G3.MyFlied.mas[0, 0].e;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            bool answer = false;
            bool tru_answer = G3.MyFlied.mas[0, 0].n;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Light();
            bool answer=k.r20.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod4()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Darkness();
            bool answer = k.r20.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod5()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Fonarik();
            bool answer = k.r20.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod6()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Light();
            bool answer = k.d23.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod7()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Darkness();
            bool answer = k.d04.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
        [TestMethod]
        public void TestMethod8()
        {
            Form1 k = new Form1();
            Game G3 = new Game(6, 6, 0, 0, 1, 4);
            G3.MyFlied.AddBorder('_', 0, 0);
            G3.MyFlied.AddBorder('_', 0, 1);
            G3.MyFlied.AddBorder('_', 0, 2);
            G3.MyFlied.AddBorder('_', 2, 1);
            G3.MyFlied.AddBorder('_', 2, 2);
            G3.MyFlied.AddBorder('_', 3, 1);
            G3.MyFlied.AddBorder('_', 3, 2);
            G3.MyFlied.AddBorder('_', 3, 3);
            G3.MyFlied.AddBorder('_', 4, 1);
            G3.MyFlied.AddBorder('_', 4, 2);
            G3.MyFlied.AddBorder('_', 4, 3);
            G3.MyFlied.AddBorder('_', 4, 4);
            G3.MyFlied.AddBorder('|', 1, 4);
            G3.MyFlied.AddBorder('|', 2, 4);
            G3.MyFlied.AddBorder('|', 3, 4);
            G3.MyFlied.AddBorder('|', 4, 4);
            G3.MyFlied.AddBorder('|', 0, 3);
            G3.MyFlied.AddBorder('|', 1, 3);
            G3.MyFlied.AddBorder('|', 2, 3);
            G3.MyFlied.AddBorder('|', 3, 3);
            G3.MyFlied.AddBorder('|', 1, 2);
            G3.MyFlied.AddBorder('|', 2, 2);
            G3.MyFlied.AddBorder('|', 4, 0);
            k.G = G3;
            k.strat = new Fonarik();
            bool answer = k.d03.Visible;
            bool tru_answer = false;
            Assert.AreEqual(answer, tru_answer);
        }
       
    }
}
