using Csml;
using static Software.Antilatency_Hardware_Extension_Interface_Library_Assets;
using static Api.Antilatency.HardwareExtensionInterface;

partial class Software : Scope {

    public static Material Antilatency_Hardware_Extension_Interface_Library_en => new Material(null, null,
    $"Library for {Terms.Antilatency_Hardware_Extension_Interface}")
        [new Section("How to use a library")
            [new OrderedList()
                [$"Load a library;"]
                [$"Get ILibrary;"]
                [$"Get ICotaskConstructor;"]
                [$"Launch a task with ​startTask()​;"]
                [$"Declare the operating modes of the necessary pins, obtain the corresponding interfaces(IInputPin, IOutputPin, etc.);"]
                [$"Switch the task in Run mode with ​run()​;"]
                [$"Work with the received interfaces (IInputPin, IOutputPin, etc.)."]
            ]
        ]

        [new Section("IInputPin")
            [IInputPin.CodeBlock]
            [$"`getState()` gets the current state of the pin (changes no more than once every 5ms)."]
        ]

        [new Section("IOutputPin")
            [IOutputPin.CodeBlock]
            [$"`getState()` gets the last state modified with `setState()`(a request to the device is not sent)."]
            [$"`setState()` sends a request to the device to change the state of the pin. Throws an exception if therequest could not be sent."]
        ]

        [new Section("IAnalogPin")
            [IAnalogPin.CodeBlock]
            [$"`getValue()` gets the current pin voltage in volts."]
        ]

        [new Section("IPulseCounterPin")
            [IPulseCounterPin.CodeBlock]
            [$"`getValue()` returns the number of pulses for the last period."]
        ]

        [new Info()[$"Before the task enters *Run* state, all methods of these interfaces will have default values."]
        ]

        [new Section("ICotask")
            [ICotask.CodeBlock]
            [new Info()[$"ICotaskMethods for creating pins form an initialization table only. The table will be sent to the device via the `run()` method."]]
            [$"The task is in ​Init​ state right after being launched. In this state only methods for creating pins work."]
            [$"`createInputPin()` creates a pin in input mode."]
            [$"`createOutputPin()` creates a pin in output mode. It is necessary to pass the state that the pin will takeimmediately after initialization."]
            [$"`createAnalogPin()` creates a pin in analog input mode. `refreshIntervalMs` - time (in milliseconds) of the value update. *Todo add from api* See Constants::AnalogMinRefreshIntervalMs and Constants::AnalogMaxRefreshIntervalMs."]
            [$"`createPulseCounterPin()` creates a pin in pulse counter mode. `refreshIntervalMs` - time (in milliseconds) of the update interval. *Todo add from api* See Constants::PulseCounterMinRefreshIntervalMs and Constants::PulseCounterMaxRefreshIntervalMs."]
            [new Info()[$"Currently, the system supports only the same update interval for the two pins in pulse counter mode."]]
            [$"Here is a list of reasons that can cause exceptions to be thrown when using methods for creating pins:"]
            [new OrderedList()
                [$"The ​`run()`​ method has already been called."]
                [$"The specified pin is already in use."]
                [$"The specified pin does not support the required mode."]
                [$"Refresh interval ​is not in the valid range (see Constants)."]
                [$"The maximum number of this type of pin has already been created."]
                [$"Different ​refresh interval​ for pins in pulse counter mode."]]
            [$"`run()` sends the initialization table to the device and waits for confirmation. The task then enters ​Runmode. After exiting the method, the current states of all pins in input and analog input modes will beobtained, as well as the initial states of all pins in output mode will be set."]
            [$"After switching to Run mode, you can use the necessary methods from the previously obtainedinterfaces (IInputPin, IOutputPin, etc.)."]
            [$"When the task stops, all pins are de-initialized and enter a high-impedance state (Hi-Z)."]
        ]
    ;   


}