using NUnit.Framework;

namespace OrderedJobs.Tests
{
    [TestFixture]
    public class SequenceTests
    {
        [Test]
        public void SingleLineInputReturnsSingleJob()
        {
            Assert.That(new Sequence().GetSequence(new []{"a =>"}), Is.EqualTo("a"));
        }

        [Test]
        public void TwoLineInputReturnsTwoJobs()
        {
            Assert.That(new Sequence().GetSequence(new[] { "a =>", "b =>" }), Is.EqualTo("ab"));
        }

        [Test]
        public void TwoLineInputWithDependencyReturnsTwoJobs()
        {
            Assert.That(new Sequence().GetSequence(new[] { "a =>b", "b =>" }), Is.EqualTo("ba"));
        }
    }
}