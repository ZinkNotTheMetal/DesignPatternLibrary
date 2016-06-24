using System.Reflection.Emit;

namespace DesignPatterns
{
    /// <summary>
    /// Why? - 
    /// Benefits - 
    /// Uses? - 
    /// Why not everywhere? 
    /// </summary>
    public class StatePattern
    {
        public void ShowPattern()
        {
            CellPhone phone = new CellPhone();

            //Should return "Already off"
            var shouldAlreadyBeOff = phone.TurnOff();

            //Turn On
            var successTurningOn = phone.TurnOn();

            //Turning On Again ShouldFail
            var shouldAlreadyBeOn = phone.TurnOn();

            //Making A call should be successfull
            var successMakingCall = phone.MakeCall();

            //Making another Call should fail
            var shouldAlreadyBeOnCall = phone.MakeCall();

            var successPlacingOnHold = phone.PlaceCallOnHold();

            var failTurningOff = phone.TurnOff();

            var successHangingUp = phone.HangUp();

            var successTurningPhoneOff = phone.TurnOff();
        }
    }



    /// <summary>
    /// What states can we have with the system?
    /// What can we do within each state?
    /// </summary>
    public class CellPhone
    {
        public CellPhone()
        {
            OffState = new OffState(this);
            OnState = new OnState(this);
            InCallState = new InCallState(this);
            OnHoldState = new OnHoldState(this);
            _currentState = OffState;
        }

        public ICellPhoneState OnState { get; set; }
        public ICellPhoneState OffState { get; set; }
        public ICellPhoneState InCallState { get; set; }
        public ICellPhoneState OnHoldState { get; set; }

        private ICellPhoneState _currentState { get; set; }

        public string TurnOn()
        {
            return _currentState.TurnOn();
        }

        public string TurnOff()
        {
            return _currentState.TurnOff();
        }

        public string MakeCall()
        {
            return _currentState.MakeCall();
        }

        public string HangUp()
        {
            return _currentState.HangUpCall();
        }

        public string PlaceCallOnHold()
        {
            return _currentState.PlaceCallOnHold();
        }

        public void SetState(ICellPhoneState setter)
        {
            _currentState = setter;
        }
    }

    public class OnState : ICellPhoneState
    {
        private readonly CellPhone _phone;

        public OnState(CellPhone phone)
        {
            _phone = phone;
        }

        public string TurnOn()
        {
            return "Cannot turn on now, device is already on";
        }

        public string TurnOff()
        {
            _phone.SetState(_phone.OffState);
            return "Success, turning phone off...";
        }

        public string MakeCall()
        {
            _phone.SetState(_phone.InCallState);
            return "Calling Home...";
        }

        public string HangUpCall()
        {
            return "Cannot hang up on a call, not on a call yet";
        }

        public string PlaceCallOnHold()
        {
            return "Cannot place on hold, not on call yet.";
        }
    }

    public class OffState : ICellPhoneState
    {
        private readonly CellPhone _phone;

        public OffState(CellPhone phone)
        {
            _phone = phone;
        }
        public string TurnOn()
        {
            _phone.SetState(_phone.OnState);
            return "Success, turning on phone...";
        }

        public string TurnOff()
        {
            return "Cannot turn phone off, phone is already off.";
        }

        public string MakeCall()
        {
            return "Cannot make a call, phone is turned off.";
        }

        public string HangUpCall()
        {
            return "Cannot hang up call, phone is turned off.";
        }

        public string PlaceCallOnHold()
        {
            return "Cannot place a call on hold, phone is turned off.";
        }
    }

    public class InCallState : ICellPhoneState
    {
        private readonly CellPhone _phone;

        public InCallState(CellPhone phone)
        {
            _phone = phone;
        }
        public string TurnOn()
        {
            return "Cannot turn phone on, phone is already on.";
        }

        public string TurnOff()
        {
            return "Cannot turn phone off, phone is in the middle of a call";
        }

        public string MakeCall()
        {
            return "Cannot make another call while current call is taking place";
        }

        public string HangUpCall()
        {
            _phone.SetState(_phone.OnState);
            return "Success, hanging up phone call...";
        }

        public string PlaceCallOnHold()
        {
            _phone.SetState(_phone.OnHoldState);
            return "Success, placing call on hold";
        }
    }

    public class OnHoldState : ICellPhoneState
    {
        private readonly CellPhone _phone;

        public OnHoldState(CellPhone phone)
        {
            _phone = phone;
        }
        public string TurnOn()
        {
            return "Cannot turn phone on, phone is already on.";
        }

        public string TurnOff()
        {
            return "Cannot turn phone off, phone is in the middle of a call.";
        }

        public string MakeCall()
        {
            _phone.SetState(_phone.InCallState);
            return "Success, calling friend...";
        }

        public string HangUpCall()
        {
            _phone.SetState(_phone.OnState);
            return "Success, hanging up call that was on hold";
        }

        public string PlaceCallOnHold()
        {
            return "Call is already on hold.";
        }
    }


    public interface ICellPhoneState
    {
        string TurnOn();

        string TurnOff();

        string MakeCall();

        string HangUpCall();

        string PlaceCallOnHold();
    }
}
