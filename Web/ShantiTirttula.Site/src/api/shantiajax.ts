export function ShantiApiPost(path: string, data: object, params?: any){
    var reqPath = '';
    if(params != null)
        reqPath=`${process.env.REACT_APP_API_URL}${path}${params}`
    else
        reqPath=`${process.env.REACT_APP_API_URL}${path}`

    return fetch(reqPath, {
        method: 'POST',
        headers: {
          "Accept": "*/*",
          "Content-Type": "application/json"
        },
        body: JSON.stringify(data)})
        .then((response) => response.json())
        .then((json) => ({
          data: json.data,
          success: json.success,
          errorMessages: json.errorMessages
        }))
        .catch(() => { throw new Error('Data Loading Error'); });
}

