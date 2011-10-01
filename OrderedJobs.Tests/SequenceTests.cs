using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void SingleLineInputReturnsSingleJob()
        {
            Assert.That(new SequenceImp().GetSequence(new []{"a =>"}), Is.EqualTo("a"));
        }

        [Test]
        public void TwoLineInputReturnsTwoJobs()
        {
            Assert.That(new SequenceImp().GetSequence(new[] { "a =>", "b =>" }), Is.EqualTo("ab"));
        }
    }
}