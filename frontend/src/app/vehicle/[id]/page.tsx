"use client";
import { useParams } from "next/navigation";

export default async function page() {
  const params = useParams<{ id: string }>();
  return <div>page</div>;
}
