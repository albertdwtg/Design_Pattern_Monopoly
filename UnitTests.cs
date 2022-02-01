using Microsoft.VisualStudio.TestTools.UnitTesting;
using Final_Project_Cohen_Watrigant;

namespace MonopolyTest
{
    [TestClass]
    public class UnitTests

    {
        [TestMethod]
        public void Validaion_Update_Position()
        {
            Player test = new Player("test", new ConcreteStatePlay());
            Dice d1 = new Dice();
            Dice d2 = new Dice();
            test.position_index = 35;
            d1.dice_f = 4;
            d2.dice_f = 3;

            test.Update_Position(d1, d2);

            int expected = 2;

            Assert.AreEqual(expected, test.position_index, 0, "Incorrect position");

        }

        [TestMethod]
        public void Validation_MoveToJail()
        {
            Player test = new Player("test", new ConcreteStatePlay());
            Singleton s = Singleton.Instance;
            Board plateau1 = s.plateau;
            plateau1.construction();
            test.turn = true;
            test.node_pos = plateau1.instance.head;
            plateau1.MoveToJail(test);
            int expected = 10;

            

            Assert.AreEqual(expected, test.node_pos.data.index, 0, "Incorrect position");
        }


    }
}
