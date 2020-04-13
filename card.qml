"Demo10FullbodyUsingPicoG2":2 {    
    "Fullbody":10{
        "HeadPicoG2"{
            ACHA0Alt__A
        }
        "Hand":2{
            ACHA0Alt__A
            ACHA0Bracer__RA
        }
        "Leg":2{
            ACHA0Alt__A
            ACHA0Socket__RA //tag
        }
    }
    TrackingArea10m2:10
}


"Demo10FullbodyUsingPicoG2":2 {    
    "Fullbody":10{
        "Hand":2{
            ACHA0Alt__A
            ACHA0Bracer__RA
        }
        ACHA0Alt__A:3
        ACHA0Socket__RA:2
        "Leg":4{
            ACHA0Alt__A
            ACHA0Socket__RA //tag
        }
    }
    "Fullbody":10{
        "HeadPicoG2"{
            ACHA0Alt__A
        }
        "Hand":2{
            ACHA0Alt__A
            ACHA0Bracer__RA
        }
        "Leg":2{
            ACHA0Alt__A
            ACHA0Socket__RA //tag
        }
    }
    ""{}
    TrackingArea10m2:10
}

[MyFullbody][10^v][Merge][:]

GroupMenu{
    Delete
    Explode
    AddGroup
    AddProduct{
        ACHA0Alt__A
        ACHA0Socket__RA
        ACHA0Bracer__RA
    }
    Add

}





ACHA0Alt__A:50
ACHA0Bracer__RA:20
ACHA0Socket__RA:20
TrackingArea10m2:10
