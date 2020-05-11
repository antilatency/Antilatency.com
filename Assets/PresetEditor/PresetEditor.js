function PresetEditor(element) {
    this.element = element;

    //window.addEventListener("hashchange", funcRef, false);
    console.log(location.hash)
    var source =
        `"Demo:_10FullbodyUsingPicoG2":2 {    
            "Fullbody":10{
                "HeadPicoG2"{
                    ~ACHA0Alt__A
                }
                "Hand":2{
                    ~ACHA0Alt__A
                    ~ACHA0Bracer__RA
                }
                "Leg":2{
                    ~ACHA0Alt__A
                    ~ACHA0Socket__RA
                }
            }
            ~TrackingArea10m2:10
        }`
    var sourceJson =
        `{
            "Demo: 10 FullbodyUsingPicoG2~2":{
                "Fullbody~10":{
                    "HeadPicoG2":{
                        "ACHA0Alt__A":1
                    },
                    "Hand~2":{
                        "ACHA0Alt__A":1,
                        "ACHA0Bracer__RA":1
                    },
                    "Leg~2":{
                        "ACHA0Alt__A":1,
                        "ACHA0Socket__RA":1
                    }
                },
                "TrackingArea10m2":10
            }
        
        }`;


    this.HashToObj = function (hash) {
        return JSON.parse(hash);
    }

    this.ObjToDom = function (obj) {
        console.log(obj)
        var keys = Object.keys(obj);
        for (let i = 0; i < keys.length; i++) {
            var value = obj[keys[i]];
            typeof(value)
            console.log(keys[i] + ":" + typeof (value)+ " = " + value)
        }
    }


    this.obj = this.HashToObj(sourceJson);
    this.ObjToDom(this.obj);

    this.Head = new RegExp('((".+")|(\w+))\s*(\:\s*\d+)?\s*');

    this.Minify = function (hash) {
        const clearOpen =  /[^\S]*{[^\S]*/g;
        const clearClose = /[^\S]*}[^\S]*/g;
        const clearColon = /[^\S]*:[^\S]*/g;
        const clearNewline = /[^\S]*[\n\r][^\S]*/g;
        hash = hash.replace(clearOpen, "{");
        hash = hash.replace(clearClose, "}");
        hash = hash.replace(clearColon, ":");
        hash = hash.replace(clearNewline, "");
        hash = hash.replace(/^[^\S]+/, "");
        console.log(hash)
    }

    //var min = this.Minify(source);


    this.OnWindowResize = function () {
        
    }

    this.OnDOMContentLoaded = function (event) {
        this.OnWindowResize();
    }

}