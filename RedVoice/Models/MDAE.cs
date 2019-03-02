using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CNTK;

namespace RedVoice
{
    public delegate Function EncoderBuilder(Variable input, string name);
    public delegate Function DecoderBuilder(Variable input, string name);
    public delegate Function LossBuilder(Variable modelInput, Variable modelOutput, string name);



    /// <summary>
    /// MultiDecoderAutoencoder
    /// </summary>
    public abstract class MDAE
    {
        private Variable _modelInput;

        private Function[] _encoderInputs;
        private Function[] _encoderReferences;
        private Function[] _decoders;

        private Function _modelFunction;
        private Function _modelLoss;

        public int DecodersCount { get; }

        protected MDAE(EncoderBuilder encoderBuilder, DecoderBuilder[] decodersBuilders, LossBuilder lossBuilder)
        {
            DecodersCount = decodersBuilders.Length;

            // Combined Audio Input
            _modelInput = Variable.InputVariable(NDShape.CreateNDShape(new int[] { DecodersCount, NDShape.FreeDimension }), DataType.Float, "Abstract_ModelInput");

            // Encoder inputs
            _encoderInputs = new Function[DecodersCount];
            for (int i = 0; i < _encoderInputs.Length; i++)
            {
                _encoderInputs[i] = CNTKLib.Slice(_modelInput, new AxisVector(new Axis[] { new Axis(0) }), new IntVector(new int[] { i }), new IntVector(new int[] { i + 1 }), "Abstract_EncoderInput_" + i);
            }

            // Encoder References
            _encoderReferences = new Function[DecodersCount];
            _encoderReferences[0] = encoderBuilder(_encoderInputs[0], "Abstract_Encoder");

            for (int i = 1; i < _encoderReferences.Length; i++)
            {
                _encoderReferences[i] = _encoderReferences[0].Clone(ParameterCloningMethod.Share, new Dictionary<Variable, Variable>() { { _encoderInputs[0], _encoderInputs[i] } });
            }

            // Decoders
            _decoders = new Function[DecodersCount];
            for (int i = 0; i < _decoders.Length; i++)
            {
                _decoders[i] = decodersBuilders[i](_encoderReferences[i], "Abstract_Decoder_" + i);
            }

            // Combined Output
            _modelFunction = Function.Combine(_decoders.Select(d => d.Output).ToList(), "Abstract_ModelFunction");

            // Loss
            _modelLoss = lossBuilder(_modelInput, _modelFunction.Output, "Abstract_Loss");
        }

        public Value Evaluate(int decoderIndex, Value inputData, DeviceDescriptor computeDevice)
        {
            Dictionary<Variable, Value> inputDict = new Dictionary<Variable, Value>() { { _encoderInputs[decoderIndex], inputData } };
            Dictionary<Variable, Value> outputDict = new Dictionary<Variable, Value>() { { _decoders[decoderIndex].Output, null } };

            _decoders[decoderIndex].Evaluate(inputDict, null, computeDevice);

            return outputDict[_decoders[decoderIndex]];
        }

        public void Train()
        {
            
        }

        public void Save(string directory) => _modelFunction.Save(Path.Combine(directory, GetType().Name + ".model"));
        public byte[] Save() => _modelFunction.Save();

        public void Restore(string directory) => _modelFunction.Restore(Path.Combine(directory, GetType().Name + ".model"));
    }

    public class MDAEImplV1 : MDAE
    {
        public MDAEImplV1() : base(BuildEncoder, new DecoderBuilder[] { BuildDecoder, BuildDecoder }, BuildLoss)
        {

        }

        protected static Function BuildEncoder(Variable input, string name)
        {
            throw new NotImplementedException();
        }

        protected static Function BuildDecoder(Variable input, string name)
        {
            throw new NotImplementedException();
        }

        protected static Function BuildLoss(Variable modelInput, Variable modelOutput, string name)
        {
            throw new NotImplementedException();
        }
    }
}
