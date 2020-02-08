using NUnit.Framework;
using Playground.DataStructure;
using Playground.Interview;

namespace Tests
{
    class LeetCode
    {
        [Test]
        public static void SwapNodesInPairs()
        {
            Playground.DataStructure.LinkedList<int> list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            var listQ = new LinkedListQ<int>(list1);
            listQ.SwapNodesInPairs();
            Assert.That(listQ.Head.Value == 2);


            list1 = new Playground.DataStructure.LinkedList<int>();
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            listQ = new LinkedListQ<int>(list1);
            listQ.SwapNodesInPairs();
            Assert.That(listQ.Head.Value == 2);
        }

        [Test]
        public static void CoinChange()
        {
            DynamicQ dyn = new DynamicQ();
            int res = DynamicQ.CoinChange(new int[] { 3, 5}, 11);
            Assert.IsTrue(res == 3);
        }

        [Test]
        public static void SearchInRotatedSortedArray()
        {
            int index = ArrayQ.SearchInRotatedSortedArray(new int[] { 7, 1, 2, 3, 4, 5, 6 }, 2);
            Assert.That(index == 2);
        }      

        [Test]
        public static void TriplesInGeometricProgression()
        {
            System.Collections.Generic.List<long> list = new System.Collections.Generic.List<long>();
            list.AddRange(new long[] { 1, 2, 1, 2, 4 });

            Assert.That(DictionaryQ.CountTriplets(list, 2) == 3);
        }

        [Test]
        public static void IsStringMatchs()
        {
            string[] a = new string[] {
                "ERreEerREeerErrrrRRyeReErrerrereEEeRRErRrrereeeeerErereerReRereeeeCrreErREreeerrRrRERreeererererEeEEeerrerrereeRRerreeerrreRererereeSerEeeRereerrReErrrereErrerrrreererrsRRecerEreeRrrreRereerErrRRrrEeEererRrrreRerReRrereererereEeereEereesrERreReeerReErEeeeeRererReereRereerRrrRRerrerreeereEeeereerrEreeERreReRrEErRRerEereeeRreeErReerrEerEeEreerrTeeeEErreRErrerreeeeereeEeerERErRrereerreerRrrreerEreeRrErreeeRReRerrreerrEreerrerEeEeerreeeeEeerRrrerrsrerrereReREerEerrRerRErereRreerRreRReEeeeRerRereeerRerererrerrrreeReeERereeeesrrEerrrreeeeerrrrereeeeeerRrRrreeereRrreeseERrrrerReeeerreeeeereEerErrrRrreeeerRerrrrrErRreREeeerrrrrrrErrreerrRrereerrRrEEErsREeeerReEeErrrrRrRererereeererreereeRreerrerREeEReereerrrrrrereereeeerEeeeerreerSrReererrRereREreereErEReEReeeerrerEeeEeeRreeeRreeeEreeeeEreerrrEeereeerrrrERrRERReeerreEeJEEeSEeeeEeEeeRrRrrreeeRerrreerEreeererEereeeeRRrreReRrEerreEreeeerEErRrRrrrrerrereeEERErerreerrRrrreeeErEeErEreRrErRrErrreeeereeerrrrSeReeeeRerrrrerrEreerEeeeeeeerrreerreRerrREr",
                "rReRRREreEreERRrreeeRrrrErReerreererEreEEseeEeErreEEereeerrerREreeeeerreeerrEEEReErrEeeeeREesrRerereRrreRreRRrreeEeEeERerrreweRrrEREEerRrrreRRrrEREreEerrrerrRerReeeerrErrreREreerrrRrreeereEseErreerrEreererRreereerrreeRrreEreerreRRErRERereEEerReReeEERrEEeeEeEeereeReeeeeReEerEREReseereRereEeeerEreEEereerEeEesrerrRerrererrerrReERrreeereeeeRerrEeeEerreRRrrRErseeErrEeeeerreeRErrRrRerrrrrerRErrerEeeeerrreerrreErrerEeeeeRRererrEReEeeererErErErRerrerErRrrRRrerrErrerrreErerrrreerreERReRerererErreRrererreRrReEERRereeeErEreeREEeeeErReRrreerRrRrreeRrRrEEEEereeerErrrerreErErrRRrreErReReRerrrerEereRreerererReERREeeeeeEeRerRerReeSrreesreeeeREeErresreeReeRrerrrrererrrrrreerrrrrrRREEerrerrErRRRereeerrREEreeEeerrEeeereeerReRerrrEEerrEEReEeerErerRrErSerErRRreERrerEeeerereEreEeerrREEEReereeRErerRrrrReeReEERrrerereereeErEEREeRSreRrRrreerrrReErReErerreerrrRrseererrerererrrreEeeRReRrerreeRerrRRerRPeeRerrreeRrrREereeEErererrRRRererrrerEEerrRrrReerRereeEerrsREEReEerEreEErrrsErreErereeerrrrRrrEeeErReEeReEeeeeEe",
                "yllyyyyllyyllyyyyllylyylyyyllllyyyyyyyllllylllylyylyllyylylyllyllllylyylylllyllyyllyyllylllyyyyyyllyyyyllllylyyyllllylyllylyyyllyllyyylylyyllllyllyyyyyllylyllllllllyyyllyllyyylyylyyyyyyyylyyyllyylyylyyllylyllllyyyyllyylyyyyyyyyylyyyyllyylyylllyylylyylyyylllylyllylyyyylyllylylllylllllyylylyylllllyylylyylllylyyyyllyyyyyyylyllyyllllyllyyylyyllllllyyllyylllyylllyllyyyyylyllyllyyyllylyyyyllyylyllyyyyyyyylllyyyyyylyylyylylyyyyyyylllyyyyylylyllllyyyylyyllylyyylyllyyllyyyyyyyyylylllylylllyllylllyllylyllylyllylyllyyllllylllllyyyylllylllyllyllyylllyyyyllyllylylylyylyylyylyyylylllylylyylllllyyyllylylyylylllllyylyllyyylylyyyylyylyllylyyllylyllyyyylyyyyylyyyylclyylylylylyllyyylyyyllllllllylyllyylylylllyylylylylyyylyllyylyyllyyyyyyylllyyyyylllylyyllyylylyylllyyylylyyyllyllyyllylyllyylylylyylylyyyylyllllyyyylylylylllllllllylyllyllylllyyylylyyllylllylyylyylylyyylylyylyyyyllyyllylylyllyylyllylyyyyllyllyllylyyyllllylylllyllllyylllyyyyylylyllyllylylylllyyyllllylylyllllyylyllyyyyylyyyyylyllylyyyyylyylelyy",
                "rararaarraraaraArarrrraaaqararraararrrrrrraarrrrarAarraaaarraaryrraaarrraararrardaaarrrRaaarrRraaRarrrrrarraraaaaarrrarrararraarrararrrraraaaaarrarrrrraaarrrrarrrarararraraaaaaarrrararrrraRaraAraaraARARaraarraarararaarrarrArAraAarrrrarrrrRrrraraaraaarrraraaarrrarrrraRarararrraraaraaarraaaaaAaaarrrararraaaaararRaaarraaaRrarraraaaaraaarrrarraarraaraaarrraaaaararrrwraraaaraarraaarrraaararaaarraraaaaarrrrarrrraaaarrarrrrrararararararrArarraaaaraAArrrarrrArrArrAraarRrraraaaAraaarrrarraarnraaaaarraaraaaaraaararaaarrarraarraararraaraAaraaaraaaaaaaaArrrrrarararaaraarRaarrrrraarrraraararaaararaarraAraaaaArrAraarArrararrraarrararrrarRarrrrrrarrrrarraarraarrarrraraaaaararAarararaarraaRararrArarAaraaarrrrraaaaarrrraararraaraaraauaraaaaraaarrrarrrrrraarroaraarrrrarraraRrrraaaaarrraarraarrrraararrrrhraarrarrraaaaarararRrarArrrraraaaarArraarraarraraaaraarrrAaaaraaraaaaraaararaArrrraaarrararrarrraararaarrrrrarArrarrrraaaraarrrraaRarrrrararaaararrrarrararaaarararraarRraaarRrrrrraraarrraraarraraarrRarar",
                "rrrrrrRRRrrrrrrRrrrrarrRrRrrrrrrrRrRrRrRrrrRrrrrrRrrrrrrRrrrrrRRrRrRRrrrrrrRrrRrrArrrRrrrarrrrrrrrrRrrRrrrrrRrRarrrrrrrrrrrrrRrrrrrrrrRrrrRrRrrrRrRrrrrRrrrrrrrrRrrrrrrrRsrrrrrRrRrrrarrRrrrrrRrrRrrRrrRrrarRrarrrrrrrrrrrrarrrRrrrRrRrrRrrrrrrrrrrRrrrrrRRRrRrrrrrrrrrrararrrrRrRrrrrrRrrRrrRrrrrrrrrRrrRrrrrrRrRrrRrrrrrrrrRrrrrrRRrrrrRrrrrrrRrrrrrRrrrrrRrrrRrrrRrrrrrarRrrRRrrrRrrrrRrrrrrraRrRrrrrrRarrrrrrrrrRrrrrrrrrRRrrarRrrrrrrrRrrrrrrrrrrrRrrRrrrrRrrarRrrrRrrRrrrrrRrrrrRrrrRrRrrrrRrRrrRrrrrrrrRrrrrrrrrrRrrrrrrrrrrrrrrrrrRrrrrRRrRrarrrRRrrrrrrrrrrrrrrrrRrrrrrrrrrrrrrRrrRrrrRrrrrrrrrRrrrrrrRrrRrrrrrRrrrrrRRrrRRrrrRrRRRRrrRrrrrRRARrrrrrrrrrrRRrrrrrRrrrrrRrrrRrrrrrrrrraRrRrrrrRrArrrrrrrRrrrrrrrrrrrrrrrrRrrrrrRRrrrkrrrrrrRRrarrRrrrrrrrRrrrrRRrRrrrrrrRrRrrrrrrrrrrRrrrrRrrarrRRrRrrrrrArrrRRrrrrrrRrrrrrrrrRrrrrRrrRrRRrrrrRrrrrrrRRrarrRrrRrkrrrrrrrrrrrrRArrrRrrrrRrrRrRRrrrrrRrRrrrRrrrrrrrrrrRrrrrRRRrrrrrRrRrRrrrRrArrrRrrRrrarrrrrrrRCrrrrrrrrrrrrrrrraRrrrrraarrrrrRrrRArrrrrrRrrrRRrrrrrrrrrrrrrrrrRrR",
                "bbbbbbbbbbbbbbbbbbbbbbobbBbbbobbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbotbbbbbbbbbbbbbbbbbbbbbbBbbbbbbbbbbbbbbbbbbbbbbbbobbbbbbbbbbbbbbbbbbtbbbbbbbbBbbbbbbbbbbbbbbbtbtbbbbbbBbbbbbbbbbbbobbbbbbbbbbbbbbbbbbobbbbbbbbbbobbbBbbbbbbbbbbtbbbbbbbbbbbtbbbbbbbobbbbbbbbbbbbobbbbbbbobbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbBbbbbbbbbbobbbBbbtbbbbbbbbbbboBobbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbobbtbbbtbbbbbbbbbbbbbbbobbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbBtbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbtbbbbcbbbbbbbbtbbbbbbbbbbbbbbbbobbbbbbbbbbbbbbbbbbbbbbbbBbbbbbbbbbbbbbbbbbbbbbbbbobbBbbbbbbbbbbbbbbbobbbbbbbbbbbbobbbbbbbbbBbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbobbbbbbbbbbbbbbbbbbbbbbBbbbbBbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbobbbbbbbbBbbbbbbbbbbbBbbBbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbbbbtbbbobbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbtbobBbbbbbbbbbbbBoobbbbbbbbbbbbbbbbbbbobbbbbbbobbbbbbbbobobbbtbbBbtbbbbtbbbbbbbbbbbbbbbbbbbbbtbbbobbtbbbbbb",
                "rrrarrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrbrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrarrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrorrrrrrrrrrrrrrrrrrrrrrrrrkrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrmrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrraarrrrrarrararrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrarrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                "bbbbbbbbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbibbbbbbbibbbbbbbbbbbbbbbbbbbbubbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbttbbbtbbbbbbbbbbbbbbtbbbtbibbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtibbbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbubbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbiibbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbbbbbibbbbbbbibbibbbbbbbibbbbbbibbbbbbbbbibbbbibbbbbibbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbbbbbbbbbbtbbbtbbbbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbtbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbbbtbbbbibbbbbbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbbibbbbbbbbbbbbbbbbb",
                "bbbbrtbbbbbbbbbbbbBbbbbbbobbbbbbbbbbrbbbbbbbsbbbbbbbbbbbbbbbbbbbbbbbsbbbbbbbbbobbbBbbrbbbbbbBbbbbbbbbbbbbbbbbbbbbbbbBsBbrbbbbbbbbbbbbbbbbbbbBbbbbbbbbbbbbBotbbbbbbbbbBbbbbbbbbbbbbbbbbbbrbbbbbBbbbbbbbbrbbbbbbbrbbbsbbbbobbbbbrbbbbbbbbBbbbbbbbbbbbbbbbbbbbbbbbbsbbbbbobbbbbbBbbbbBbbBbbbbbbbbbbbbbbbbbbbbbbtbbbbBbbbbbbbrbbbbbsbbbbbbrbbbobbbbbbbbbbbBbbbbbbbbbrbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbtbBbbsbbbbbbbbbbbbbbbbbbbbbbbbbbbtbbbbbbbbbbbbbbbrbbbbbbbbbbbbbbbbbbbbbbbbbbbBbbbbbbbbbbbbbbbbbbrbbbsbbBbsbbbbBbbbbbbbbbbbbbbbbbbbbbbbbbobBsBbbbbbbbbbbbrbbbbbbbbbbbbbbbbbsBbbbbbbbbbbbBbbbbbbbbbbbbbbrbbbbsbbbobtbbbbbbbbbbbObbbrbbbbBsbsbbbbbbbrbObbbobbbbbbbbobbbbtbtbosbbbbbbbbbbbbsbbObbbbbbrbbbbbBbbbbbrbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbsobBbbbbbbbbbbbbbbbbbbbbbbbbbbrBbbbobbbbobBbbbbbbbbbbbbbbrbbbbbbobbbbbbbbbbbBbBtbbbbbbrbbbbbbBbbbbbbtnbbbbbbBbbbbbtbtbbbbbbbbbbbbbrtbbbbbbbbbbrbbbbsoBobbbbbbbsbbbBbbbbbbbbbbbbbbobbsbbbbbbbbbbsbbobBbbbbbbbbbbosBbbbbbbbbbbbbbobbbbbobbbjbbbsbbBbbbbbbbbs",
                "ssssssssssssssssssssiisssissstsssssssssssssssssssssssssstsssslssssgsissstsssssssssslssssssssssssisssssssssisssssitssssssstslsssssssssssssssssssssstsssssssssssssbssssstsssssspssssssssssssssssssssssssssspssssssssssssssssssspssssssssssitsslissssssssssssssssssssssssssssssssssssssssssssssisssssslsslsssstsssssssssssslsssssssisssssssssssstsssssisssssssssssslsssssssssssssssssssssssssssssssssssssssssssssssssslstsssssssssssissssssssisssssssssspsssssssssssssssssssssssspsssssissssssssissssssssstspsssssstssssssssssslssslspssssssssssssssssisssssssssssssssssisssspssssssssssisssssssssssssssssstsssssssissssssssssssssssspslsssssssssstssssspsssssnssssslsssssssssssssssssssssissssssssssssssstsslssssssssssspsssssssssssisssssssssssssssstssssssssstsssslssspsssssssssssssspississspssssssssssstsssslpssssssssissssssssssssssssssssssstssssssssssssisssssssssssssslsssssssssssstsssssssssssisssssssssssssssssssssssssssstssssissssssssssssssssssssssssssspslsssssssissssssissssssssssssssspssssssssssssssssssssssssssissssssls"
            };

            string[] b = new string[] {
                "ERREREERERRREERREERRERRREEEERRREREEECEREERRRERREEEERRREERRERRRRSERERERERERERRRRRREERREREERRREEERERRRRRRREREEESEREREREEEERRERERRRERRRRREEREREERERREERRERRERREREEEERRTEEEEREEREEEEEEEERERRRRERREERREREERRREREREEREEREEERRRERERERREEREERRERRERERERRRREEERRREERRRRREREREREEEEERRRRRRRREERRERRERRRERERRREEERRRRERRERERRRERRRREREERREEESREEREERRRERREEEERRERERREEREREEREERREEEEEERRRSRERREREEEERERREREEERRERREEEEEEEREEERERRERREREEJEESEEEEEEERRRREEREREEEEEERERRRRRRREEEEREERRREEREEERRREEEEREERRERRERRRSREEERERREERRRRER",
                "RRRREERERREERRERREEEEEEEEEERRREREEERRREEEEEEREESRRRRRRREEERRRREERRERREREEREREEERERRREERRRRESERERRERRRREEEEERREREREEEERREEERREEEEEEREEEREEERERERREEREREEEEEERRREREERRREERRRRRREEREEEERERREREREERRREEREREERREREREEREERERERRRERERERERRRREERRRERERRRERRREERREEEEEREREEREEEERRRREERRRRERRREEEERERERERRRERRREEREEREERERREEEERRRESRESEREESRERRRRRRRERRRREEERERRRRERREEEEEEEEERRRRRREREEREEEERRESRRRRRREREEEEREERREEERRERRRREEERREEEEEERRSRRRERRERREERREERRRREERRRRRRRRRRPRRREEEEEEERRREEERRRRRERREEREEEEEREREEEERREEEREEREE",
                "LLYYYLYYLLYYYLLYLYYLYYYLLLLYYYYYYYLLLLYLLLYLYYLLLYYLYLYLLYLLLLYLYYLYLYLLYYLLYYLLYLLLYYYYYYLLYYYYLLLLYYYYLLLLYLYLLYLYYYLLYLLYYYLYLLLLYLLYYYYYLYLYLLLLLLLLYYYLLYLLYYYYLYYYYYYYLYYYLLYYLYYLYYLYLYLLLLYYYYLLLYYYYYYYYYYYLLYYLYYLLYYLYLYYLYYYLLLYLYLYLYYLYLLYLYLLLYLLLLYYLYLYYLLLLYYLYYYLLLYLYYYLYYYYYYYLYLYYLLLYLLYYYYLLLLLLYYLLYYLLLYYLLLYLYYYYYLYLLYLYYYLLLYYYYLLYYLYLLYYYYYYLLLYYYYYYLYYLYYLYLYYYYYLLYYLYLYLLLLYYYYYLLYLYYYLYLLYLLYYYYYYYYYLYLLLYLYLLLYLLYLLLYLYLYLYLYLYLYLLYLLLLYLLLLLYYYYLLYLLLLLYLYYLLLYYYYLLYLYLYLLYYLYYLYYLYYYLYLLLYLYLYYLLLLLYYYLLYLYLYYLYLLLLYYLYLLYYYLYYYYLYYLLLLYYLYYLLYYYYLYYYYLYYYLLYYLYLYLYLYLYYYLYYYLLLLLLLLYLYLLYLYLYLLYYLYLYLYYYLYYYLYYLLYYYYYYYLLLYYYYYLLYLYYLLYYLYLYYLLLYYYLYLYYYLLYLLYLLYLYLYYLYLLYLYLYYYLYLLLLYYYYLYLYLYLLLLLLLLYLYLYLLYLLLYYYLYLYLLYLLYLYYLYYLYLYYYLYLYYLYYYYLLYYLLYLYLLYYLLLYYYYYYLLYLYLYYLLLYLYLLYLLLYYLLLYYYYYLYLYLLYLYLYLLLLYYYLLLLLYLYLLLLYYLYLLYYYYYLYYYYYLYLYLYYYYYLYYLLYY",
                "RARARAARRARAAAARRRRRAAAARARRAARARRRRRRRAARRRRARAARRAAAARRAARRRAAARRRAARARRARAAARRRRAAARRRRAARARRRRRARRARAAAAARRRARRARARRAARRARARRRRARAAAAARRARRRRRAAARRRRARRRARARARRARAAAAAARRRARARRRRARARAARAARAARARARAARRAARARARAARARRARARAAARRRRARRRRRRRRARAARAARRRARAAARRRARRRRARARARARRRARAARAAARRAAAAAAAAARRRARARAAAAARARRAARRAAARRARRARAAAARAARRRARRAARRAARAAARRRAAAAARARRRRARAAARAARRAAARRRAARARAAARRARAAAAARRRRARRRRAAAARRARRRRRARARARARARARRARARRAAAARAAARRRARRRARRARRARAARRRRAAAAARAAARRRRRAAAAAAARRAARAAARAARARAAARRARRAARRAARARRAARAAAAAARAAAAAAAAARRRRRAARARAARAARRARRRRRAARRARAARRAAARARAARRAARAAAAARRARAARARARARRRAARRARARRRARRARRRRRRARRRRARRAARRAARRARRRARAAAAARARAARARAAARRAARARARRARARAARAAARRRRRAAAARRRAARARRAAAARAAARAAAARAAARRRARRRRRRAARRARAARRRRARRARARRRRAAAAARRRAARRAARRRAARARRRRRARARRRAAAAARARARRRARARRRRARAAARARAARAARRAAAARAARRRAAAARARAAAARAARARAARRRRAAARRARRRARRRARARAARRRRRARARRARRRAAARAARRRRAAARRRRARARAAARARRRARARRAAARARARRARRRAARRRRRRRARAARRARAARRARAARRRARAR",
                "RRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRARRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRARRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRARRRRRAARRRRRRRRRRRRRRRRRRRRRRRRRRRRR",
                "BBBBBBBBBBBBBBBBBBBBOBBBBOBBBBBBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBOBBBBBBBBBBBBBOBBBBBBBBOBBBBBBBBBBBBBBBBBBBBTBBBBBBOBBBBBBBOBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBOOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBOBBTBBBTBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBTBBBBTBBBBBBBBBBTBBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBTBBBOBBBBBBBBBBBBBTBBBBBBBBBBBBBBBTOBBBBBBBOBBBBBBBBBBBBBBBBOBBBBBBOBBBBBOBBTBBBBBBBBBBBBBBBBBBBBBBTBBBBBTBBBBB",
                "RRRARRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRARRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRARRARARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRARRRRRRRRRRRRRRRRRRRRRRRRR",
                "BBBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBIBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBTTBBTBBBBBBBBBBBBBTBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTIBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBIIBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBIBBBBBBBBIBBBBBIBBBBBBIBBBBBBBBIBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBTBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBIBBBBBBBBBBBBBBBB",
                "BBBBRTBBBBBBBBBBBBBBBBOBBBBBBBBBRBBBBBBSBBBBBBBBBBBBBBBBBBBSBBBBBBBBOBBBBRBBBBBBBBBBBBBBBBBBBBBBBBBBSBRBBBBBBBBBBBBBBBBBBBBBBBBBBBBBOTBBBBBBBBBBBBBBBBBBBBBRBBBBBBBBBBBBRBBBRBBBSBBBOBRBBBBBBBBBBBBBBBBBBBBBBBBBBSBBBBBOBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBRBBSBBBBRBBBOBBBBBBBBBBBBBBBBRBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBTBBBTBBBSBBBBBBBBBBBBBBBBBBBBBBTBBBBBBBBBBBBBBRBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBRBBSBBBSBBBBBBBBBBBBBBBBBBBBBBBBBBBBBSBBBBBBBBRBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBRBBBSBBBOBTBBBBBBBBBBBRBBBBBSBBBBRBOBBOBBBBBOBTBTBOSBBBBBBBBBSBBBBBBBRBBBBBBBBBRBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBSOBBBBBBBBBBBBBBBBBBBBBBBBBBBOBBBOBBBBBBBBBBBRBBBOBBBBBBBBBBBBTBBBBBBRBBBBBBBBBBBBTBBBBBBBBBBTBBBBBBRTBBBBBBBBBRBBSOBOBBBBSBBBBBBBBBBBBBBBBOBBSBBBBBBBBBBOBBBBBBBBOBBBBBBBBBBBBBOBBBBOBBBBBBSBBBBBBB",
                "SSSSSSSSSSSSSSSSSIISSSSSTSSSSSSSSSSSSSSSSSSSSSSSSSSSLSSSSSISSTSSSSSSSSLSSSSSSSSSISSSSSSSSSSSITSSSSSTSLSSSSSSSSSSSSSSSSSSTSSSSSSSSSSSSSTSSSSSPSSSSSSSSSSSSSSSSSSSSSSSPSSSSSSSSSSSSSSSSSSSSITSSISSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSISSSSSLSSLSSSTSSSSSSSSSLSSSSSSISSSSSSSSSSSTSSSSISSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSLSTSSSSSSSSSSISSSSSSSSSSSSSSSPSSSSSSSSSSSSSSSSSSSPSSSSSSSSISSSSSSSSSPSSSSSSSSSSSSLSSSSPSSSSSSSSSSSSSSSSISSSSSSSSSSSSSSSISSSPSSSSSSSSISSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSPSLSSSSSSSTSSSPSSSSSSSLSSSSSSSSSSSSSSSSISSSSSSSSSSSSSSTSLSSSSSSSSSSSPSSSSSSSISSSSSSSSSSSSSTSSSSSSSSTSSSSSSSSSSSSSSSPISSISSSPSSSSSSSSSSTSSSSLPSSSSISSSSSSSSSSSSSSSSSSSSSSTSSSSSSSSSSSISSSSSSSSLSSSSSSSSTSSSSSSSSSSSSSSSSSSSSSSSSSSSSSTSSSSSSSSSSSSSSSSSSSSSSPLSSSSSSISSSSSISSSSSSSSSSPSSSSSSSSSSSSSSSSSSSSSISSSS"
            };

            bool[] answers = new bool[] { true, false, true, false, false, false, true, true, false, true};
            
            for(int i = 0; i < 10; i++)
            {
                Assert.That(DynamicQ.IsMatch(a[i], b[i]) == answers[i]);
            }            
        }

        [Test]
        public static void GraphTest()
        {
            /*
                    0
                 1  2  3  
                    4 
            */

            Graph graph = new Graph(5);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(0, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 4);

            string res = graph.BreadthFirstSearch(0); // 0 1 2 3 4
            res = graph.DepthFirstSearch(0);          // 0 3 4 2 1
            res = graph.DepthFirstSearchRecurcive(0); // 0 1 4 2 3
        }


        /// <summary>
        /// https://leetcode.com/problems/course-schedule/
        /// </summary>
        [Test]        
        public void CanFinishCource()
        {
            int numCourses = 8;
            int[][] prerequisites = new int[7][] { new int[] { 1, 0 }, new int[] { 2, 6 }, new int[] { 1, 7 }, new int[] { 6, 4 },
            new int[] { 7, 0 }, new int[] { 0, 5 }, new int[] { 5, 7 }};

            Graph graph = new Graph(numCourses);

            for (int i = 0; i < prerequisites.Length; i++)
            {
                int[] cource = prerequisites[i];
                int from = cource[0];
                for (int j = 1; j < cource.Length; j++)
                {
                    graph.AddEdge(from, cource[j]);
                }
            }

            bool isCyclic = graph.IsCyclic();
            Assert.That(isCyclic == true);
        }

        /// <summary>
        /// https://leetcode.com/discuss/interview-question/476340/google-onsite-min-modifications
        /// </summary>
        [Test]
        public void MinModificationsWays()
        {
            char[][] ways = new char[3][];
            ways[0] = new char[] { 'R', 'R', 'D' };
            ways[1] = new char[] { 'D', 'L', 'L' };
            ways[2] = new char[] { 'R', 'R', 'R' }; 
          
            Assert.That(Graph.GetMinModifications(ways) == 0);
        }

        [Test]
        public void SizeCompletedTree()
        {
            Tree<int> tree = new Tree<int>
            {
                Root = new Tree<int>.Node(1)
                {
                    //Left = new Tree<int>.Node(2)
                    //{
                    //    Left = new Tree<int>.Node(3)
                    //    {
                    //        Left = new Tree<int>.Node(9),
                    //        Right = new Tree<int>.Node(10),
                    //    },
                    //    Right = new Tree<int>.Node(4)
                    //    {
                    //        Left = new Tree<int>.Node(11),
                    //        Right = new Tree<int>.Node(12)
                    //    }
                    //},
                    //Right = new Tree<int>.Node(5)
                    //{
                    //    Left = new Tree<int>.Node(6)
                    //    {
                    //        Left = new Tree<int>.Node(13),
                    //    },
                    //    Right = new Tree<int>.Node(7)
                    //}
                }
            };

            TreeQ treeQ = new TreeQ();
            Assert.IsTrue(treeQ.SizeCompleteBinaryTree(tree.Root) == 1);
        }
    }
}
