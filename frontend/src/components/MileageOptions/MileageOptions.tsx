export default function MileageOptions() {
  const mileageOptions = [
    5000, 10000, 20000, 35000, 50000, 75000, 100000, 125000, 150000, 175000,
    200000, 250000,
  ];
  return (
    <>
      {mileageOptions.map((val, index) => (
        <option key={index} value={val} />
      ))}
    </>
  );
}
