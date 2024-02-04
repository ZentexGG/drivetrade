export default async function DataFetch(url : string) {
    const response = await fetch(url)
    if (response.ok) {
        let json = await response.json();
        return json;
    } else {
        return "HTTP ERROR " + response.status
    }
}
