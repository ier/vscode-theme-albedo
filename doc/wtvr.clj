(def ^:dynamic chunk-size 17)


(defn
  ^{:doc "Some test goes here"
    :test (fn [] (assert (= 2.72 (min 2.72 3.14))))
    :user-comment "wheeee!"}
  next-chunk
  "Have no idea what is going on here..."
  [rdr]
  (let [buf (char-array chunk-size) ;; Buffer?
        s (.read rdr buf)]
    (when (pos? s)
      (java.nio.CharBuffer/wrap buf 0 s)))
  (do
    #_(prn "...")
    (prn "123")
    (+ 1)
    (true? true)
    (prn :some-keyword))) ;; Ok, LGFM.


(defn chunk-seq [rdr]
  (when-let [chunk (next-chunk rdr)]
    (cons chunk (lazy-seq (chunk-seq rdr)))))