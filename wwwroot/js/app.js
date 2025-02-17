function ObjInvoke(obj, funcName, ...args) {
    return obj[funcName](...args);
}