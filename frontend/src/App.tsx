import axios from "axios";
import { useEffect, useState } from "react";
import { BrandDTO } from "./types";

export default function App() {
  const [data, setData] = useState<BrandDTO[]>();
  useEffect(() => {
    const fetchBrands = async () => {
      const response = await axios.get("/api/brand");
      console.log(response.data);
      setData(response.data);
    };
    fetchBrands();
  }, []);
  return (
    <div>
      <table>
        {data?.map((brand) => (
          <tr>
            <td>{brand.id}</td>
            <td>{brand.name}</td>
          </tr>
        ))}
      </table>
    </div>
  );
}
