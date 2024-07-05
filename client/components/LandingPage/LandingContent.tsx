import Image from "next/image";
import Link from "next/link";
import landingImage from '../../public/assets/images/landing-image.jpg'

const LandingContent = () => {
  return (
    <>
    <div className="relative">
      <Image src={landingImage} alt="Landing image" className="h-[100vh] object-cover object-left-bottom"/>
    </div>
      <main className="p-8 absolute xl:w-[500px] xl:top-1/3 xl:left-[200px] top-1/3 left-auto w-[400px]">
        <section className="flex justify-center flex-col">
          <div className="flex flex-col gap-4">
            <h1 className="text-[32px] font-bold">
              The free, fun, and effective way to learn a finances!
            </h1>
            <Link
              href="/auth/login"
              className="bg-[#1CB0F6] hover:bg-[#77ccf3] duration-300 text-white p-2 py-3 rounded-xl xl:w-[330px] items-center text-center uppercase font-bold tracking-widest shadow-[0_6px_0] shadow-[#378CE7] w-[250px] "
            >
              Get Started
            </Link>
          </div>
        </section>
      </main>
    </>
  );
};

export default LandingContent;
